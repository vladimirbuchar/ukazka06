﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Request;
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
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.CourseTermStudent.Convertor;
using Services.CourseTermStudent.Dto;
using Services.CourseTermStudent.Validator;
using Services.SystemService.SendMailService.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.CourseTermStudent.Service
{
    public class CourseTermStudentService(
        ICourseStudentRepository studentRepository,
        ICourseTermStudentConvertor courseStudentConvertor,
        IConfiguration configuration,
        ISendMailService sendMailService,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IOrganizationRoleRepository organizationRoleRepository,
        INotificationRepository notificationService,
        ICodeBookRepository<NotificationTypeDbo> codeBooService,
        IOrganizationSettingRepository organizationSettingRepository,
        IUserInOrganizationRepository userInOrganizationRepository,
        ICourseTermStudentValidator courseTermStudentValidator
    )
        : BaseService<
            ICourseStudentRepository,
            CourseStudentDbo,
            ICourseTermStudentConvertor,
            ICourseTermStudentValidator,
            CourseTermStudentCreateDto,
            CourseTermStudentListDto,
            CourseTermStudentDetailDto,
            FilterRequest
        >(studentRepository, courseStudentConvertor, courseTermStudentValidator),
            ICourseTermStudentService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly INotificationRepository _notificationRepository = notificationService;
        private readonly List<NotificationTypeDbo> _notificationTypes = codeBooService.GetEntities(false).Result;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingRepository;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;

        public override Result<CourseTermStudentDetailDto> AddObject(CourseTermStudentCreateDto addObject, Guid userId, string culture)
        {
            Result<CourseTermStudentDetailDto> result = _validator.IsValid(addObject);
            if (result.IsOk)
            {
                string email = addObject.UserEmail;

                if (email.IsValidEmail())
                {
                    UserDbo user = _userRepository.GetEntity(false, x => x.UserEmail == email);
                    if (user == null)
                    {
                        string defaultPassword = _organizationSettingRepository
                            .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId)
                            .UserDefaultPassword;
                        user = _userRepository.CreateEntity(
                            new UserDbo()
                            {
                                UserEmail = email,
                                UserRoleId = _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER).Id,
                                UserPassword = defaultPassword,
                                Person = new PersonDbo() { FirstName = addObject.FirstName, LastName = addObject.LastName }
                            },
                            userId
                        );

                        _ = _userInOrganizationRepository.CreateEntity(
                            new UserInOrganizationDbo()
                            {
                                OrganizationId = addObject.OrganizationId,
                                OrganizationRoleId = _organizationRoleRepository
                                    .GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT)
                                    .Id,
                                UserId = user.Id
                            },
                            userId
                        );

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
                            userId
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
                            replaceData,
                            addObject.OrganizationId,
                            ""
                        );
                    }
                    if (_repository.GetStudentCourse(user.Id, false).FirstOrDefault(x => x.CourseTermId == addObject.CourseTermId) == null)
                    {
                        _ = _repository.CreateEntity(
                            new CourseStudentDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                UserInOrganizationId = _userInOrganizationRepository
                                    .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                                    .Result.FirstOrDefault(x => x.User.UserEmail == email)
                                    .Id
                            },
                            userId
                        );

                        _ = _notificationRepository.CreateEntity(
                            new NotificationDbo()
                            {
                                IsNew = true,
                                NotificationTypeId = _notificationTypes
                                    .FirstOrDefault(x => x.SystemIdentificator == NotificationType.ADD_STUDENT_TO_COURSE_TERM)
                                    .Id,
                                CourseTermId = addObject.CourseTermId,
                                UserId = user.Id
                            },
                            userId
                        );
                    }
                }
                else
                {
                    result.AddResultStatus(
                        new ValidationMessage(MessageType.ERROR, MessageCategory.ADD_STUDENT_TO_COURSE, MessageItem.EMAIL_IS_NOT_VALID, email, 0)
                    );
                }
            }
            return result;
        }

        List<CourseTermStudentListDto> ICourseTermStudentService.GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return _convertor.ConvertToWebModel(_repository.GetEntities(false, x => x.CourseTermId == courseTermId).Result, string.Empty);
        }
    }
}
