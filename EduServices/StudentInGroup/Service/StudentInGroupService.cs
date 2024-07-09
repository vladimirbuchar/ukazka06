﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Model.CodeBook;
using Model.Edu.Notification;
using Model.Edu.Person;
using Model.Edu.User;
using Model.Link;
using Repository.CourseStudentRepository;
using Repository.NotificationRepository;
using Repository.OrganizationRoleRepository;
using Repository.OrganizationSettingRepository;
using Repository.RoleRepository;
using Repository.StudentGroupRepository;
using Repository.StudentInGroupCourseTerm;
using Repository.StudentInGroupRepository;
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.StudentInGroup.Convertor;
using Services.StudentInGroup.Dto;
using Services.StudentInGroup.Filter;
using Services.StudentInGroup.Validator;
using Services.SystemService.SendMailService.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.StudentInGroup.Service
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
        IStudentInGroupRepository studentInGroupRepository,
        IStudentInGroupConvertor studentGroupConvertor,
        IStudentInGroupCourseTermRepository studentInGroupCourseTermRepository,
        IStudentGroupRepository studentGroupRepository
    )
        : BaseService<
            IStudentInGroupRepository,
            StudentInGroupDbo,
            IStudentInGroupConvertor,
            IStudentInGroupValidator,
            StudentInGroupCreateDto,
            StudentInGroupListDto,
            StudentInGroupDetailDto,
            StudentInGroupFilter
        >(studentInGroupRepository, studentGroupConvertor, validator),
            IStudentInGroupService
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly List<NotificationTypeDbo> _notificationTypes = codeBookService.GetEntities(false).Result;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IStudentGroupRepository _studentGroupRepository = studentGroupRepository;

        public override Result<StudentInGroupDetailDto> AddObject(StudentInGroupCreateDto addObject, Guid userId, string culture)
        {
            Result<StudentInGroupDetailDto> result = new();
            string email = addObject.UserEmail;

            if (email.IsValidEmail())
            {
                UserDbo user = _userRepository.GetEntity(false, x => x.UserEmail == email);
                if (user == null)
                {
                    string defaultPassword = _organizationSettingRepository
                        .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId)
                        .UserDefaultPassword;
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
                                OrganizationRoleId = _organizationRoleRepository
                                    .GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT)
                                    .Id,
                                UserId = user.Id
                            },
                            Guid.Empty
                        )
                        .Id;
                    _ = _notificationRepository.CreateEntity(
                        new NotificationDbo()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes
                                .FirstOrDefault(x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION)
                                .Id,
                            OrganizationId = addObject.OrganizationId,
                            UserId = user.Id
                        },
                        Guid.Empty
                    );
                    Dictionary<string, string> replaceData =
                        new()
                        {
                            {
                                ConfigValue.ACTIVATION_LINK,
                                string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_ACTIVATE).Value, user.Id)
                            }
                        };
                    _sendMailService.AddEmailToQueue(
                        EduEmail.REGISTRATION_USER,
                        culture,
                        new EmailAddress() { Email = email, Name = "" },
                        replaceData
                    );
                }
                _ = _repository.CreateEntity(
                    new StudentInGroupDbo()
                    {
                        UserInOrganizationId = _userInOrganizationRepository
                            .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                            .Result.FirstOrDefault(x => x.User.UserEmail == email)
                            .Id,
                        StudentGroupId = addObject.StudentGroupId
                    },
                    Guid.Empty
                );
                List<StudentInGroupCourseTermDbo> getAllTermInGroups = _studentInGroupCourseTermRepository
                    .GetEntities(false, x => x.StudentGroupId == addObject.StudentGroupId)
                    .Result;
                foreach (StudentInGroupCourseTermDbo item in getAllTermInGroups)
                {
                    _ = _courseStudentRepository.CreateEntity(
                        new CourseStudentDbo()
                        {
                            CourseTermId = item.CourseTermId,
                            UserInOrganizationId = _userInOrganizationRepository
                                .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                                .Result.FirstOrDefault(x => x.User.UserEmail == email)
                                .Id,
                        },
                        Guid.Empty
                    );
                }
            }
            else
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.ADD_STUDENT_TO_COURSE, MessageItem.EMAIL_IS_NOT_VALID, email, 0)
                );
            }
            return result;
        }

        public override Guid GetOrganizationIdByParentId(Guid objectId)
        {
            return _studentGroupRepository.GetOrganizationId(objectId);
        }

        protected override List<StudentInGroupDbo> PrepareMemoryFilter(List<StudentInGroupDbo> entities, StudentInGroupFilter filter, string culture)
        {
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                entities = entities.Where(x => x.UserInOrganization.User.Person.FirstName == filter.FirstName).ToList();
            }
            if (!string.IsNullOrEmpty(filter.SecondName))
            {
                entities = entities.Where(x => x.UserInOrganization.User.Person.SecondName == filter.SecondName).ToList();
            }
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                entities = entities.Where(x => x.UserInOrganization.User.Person.LastName == filter.LastName).ToList();
            }
            if (!string.IsNullOrEmpty(filter.Email))
            {
                entities = entities.Where(x => x.UserInOrganization.User.UserEmail == filter.Email).ToList();
            }
            return entities;
        }
    }
}
