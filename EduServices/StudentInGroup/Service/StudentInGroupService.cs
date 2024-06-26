﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.CourseStudentRepository;
using EduRepository.NotificationRepository;
using EduRepository.OrganizationRoleRepository;
using EduRepository.OrganizationSettingRepository;
using EduRepository.RoleRepository;
using EduRepository.StudentInGroupCourseTerm;
using EduRepository.StudentInGroupRepository;
using EduRepository.UserInOrganizationRepository;
using EduRepository.UserRepository;
using EduServices.StudentInGroup.Convertor;
using EduServices.StudentInGroup.Dto;
using EduServices.StudentInGroup.Validator;
using EduServices.SystemService.SendMailService;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Notification;
using Model.Tables.Edu.Person;
using Model.Tables.Edu.User;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.StudentInGroup.Service
{
    public class StudentInGroupService(
        ICourseStudentRepository courseStudentRepository,
        IOrganizationRoleRepository organizationRoleRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        IUserRepository userRepository,
        IOrganizationSettingRepository organizationSettingService,
        IStudentInGroupValidator validator,
        ISendMailService sendMailService,
        IConfiguration configuration,
        ICodeBookRepository<NotificationTypeDbo> codeBookService,
        INotificationRepository notificationRepository,
        IRoleRepository roleRepository,
        IStudentInGroupRepository studentGroupRepository,
        IStudentInGroupConvertor studentGroupConvertor,
        IStudentInGroupCourseTermRepository studentInGroupCourseTermRepository
    )
        : BaseService<IStudentInGroupRepository, StudentInGroupDbo, IStudentInGroupConvertor, IStudentInGroupValidator, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto>(
            studentGroupRepository,
            studentGroupConvertor,
            validator
        ),
            IStudentInGroupService
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly HashSet<NotificationTypeDbo> _notificationTypes = codeBookService.GetCodeBookItems();
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ISendMailService _sendMailService = sendMailService;

        public override Result<StudentInGroupDetailDto> AddObject(StudentInGroupCreateDto addObject, Guid userId, string culture)
        {
            Result<StudentInGroupDetailDto> result = new();
            string email = addObject.UserEmail;

            if (email.IsValidEmail())
            {
                UserDbo user = _userRepository.GetEntity(false, x => x.UserEmail == email);
                if (user == null)
                {
                    string defaultPassword = _organizationSettingRepository.GetEntity(false, x => x.OrganizationId == addObject.OrganizationId).UserDefaultPassword;
                    _ = _userRepository.CreateEntity(
                        new UserDbo()
                        {
                            UserEmail = email,
                            Person = new PersonDbo()
                            {
                                FirstName = addObject.FirstName,
                                LastName = addObject.LastName,
                                SecondName = "",
                            },
                            UserRoleId = _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER).Id,
                            UserPassword = defaultPassword.GetHashString()
                        },
                        Guid.Empty
                    );
                    user = _userRepository.GetEntity(false, x => x.UserEmail == email);

                    Guid studentId = _userInOrganizationRepository
                        .CreateEntity(
                            new UserInOrganizationDbo()
                            {
                                OrganizationId = addObject.OrganizationId,
                                OrganizationRoleId = _organizationRoleRepository.GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT).Id,
                                UserId = user.Id
                            },
                            Guid.Empty
                        )
                        .Id;
                    _ = _notificationRepository.CreateEntity(
                        new NotificationDbo()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION).Id,
                            OrganizationId = addObject.OrganizationId,
                            UserId = user.Id
                        },
                        Guid.Empty
                    );
                    Dictionary<string, string> replaceData =
                        new() { { ConfigValue.ACTIVATION_LINK, string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_ACTIVATE).Value, user.Id) } };
                    _sendMailService.AddEmailToQueue(EduEmail.REGISTRATION_USER, culture, new EmailAddress() { Email = email, Name = "" }, replaceData);
                }
                _ = _repository.CreateEntity(
                    new StudentInGroupDbo()
                    {
                        UserInOrganizationId = _userInOrganizationRepository
                            .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                            .FirstOrDefault(x => x.User.UserEmail == email)
                            .Id,
                        StudentGroupId = addObject.StudentGroupId
                    },
                    Guid.Empty
                );
                HashSet<StudentInGroupCourseTermDbo> getAllTermInGroups = _studentInGroupCourseTermRepository.GetEntities(false, x => x.StudentGroupId == addObject.StudentGroupId);
                foreach (StudentInGroupCourseTermDbo item in getAllTermInGroups)
                {
                    _ = _courseStudentRepository.CreateEntity(
                        new CourseStudentDbo()
                        {
                            CourseTermId = item.CourseTermId,
                            UserInOrganizationId = _userInOrganizationRepository
                                .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                                .FirstOrDefault(x => x.User.UserEmail == email)
                                .Id,
                        },
                        Guid.Empty
                    );
                }
            }
            else
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ADD_STUDENT_TO_COURSE, GlobalValue.EMAIL_IS_NOT_VALID, email, 0));
            }
            return result;
        }
    }
}
