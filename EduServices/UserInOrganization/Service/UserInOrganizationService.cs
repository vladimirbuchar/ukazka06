using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.CourseLectorRepository;
using EduRepository.CourseStudentRepository;
using EduRepository.NotificationRepository;
using EduRepository.OrganizationRoleRepository;
using EduRepository.OrganizationSettingRepository;
using EduRepository.RoleRepository;
using EduRepository.UserInOrganizationRepository;
using EduRepository.UserRepository;
using EduServices.OrganizationRole.Dto;
using EduServices.SystemService.SendMailService;
using EduServices.UserInOrganization.Convertor;
using EduServices.UserInOrganization.Dto;
using EduServices.UserInOrganization.Validator;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Person;
using Model.Tables.Edu.User;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduServices.UserInOrganization.Service
{
    public class UserInOrganizationService(
        IOrganizationSettingRepository organizationSettingRepository,
        IUserRepository userRepository,
        ICodeBookRepository<NotificationTypeDbo> notificationTypeCodebook,
        INotificationRepository notificationRepository,
        IOrganizationRoleRepository organizationRoleRepository,
        ISendMailService sendMailService,
        IRoleRepository roleRepository,
        IUserInOrganizationRepository organizationRepository,
        IConfiguration configuration,
        IUserInOrganizationConvertor organizationConvertor,
        IUserInOrganizationValidator validator,
        ICourseLectorRepository courseLectorRepository,
        ICourseStudentRepository courseStudentRepository
    )
        : BaseService<
            IUserInOrganizationRepository,
            UserInOrganizationDbo,
            IUserInOrganizationConvertor,
            IUserInOrganizationValidator,
            UserInOrganizationCreateDto,
            UserInOrganizationListDto,
            UserInOrganizationDetailDto,
            UserInOrganizationUpdateDto
        >(organizationRepository, organizationConvertor, validator),
            IUserInOrganizationService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly HashSet<NotificationTypeDbo> _notificationTypes = notificationTypeCodebook.GetCodeBookItems();
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;

        public override Result<UserInOrganizationDetailDto> AddObject(UserInOrganizationCreateDto addObject, Guid userId, string culture)
        {
            Result<UserInOrganizationDetailDto> result = new();
            UserDbo user = null;
            foreach (string email in addObject.UserEmails.Distinct())
            {
                if (email.IsValidEmail())
                {
                    user = _userRepository.GetEntity(false, x => x.UserEmail == email);
                    if (user == null)
                    {
                        string defaultPassword = _organizationSettingRepository.GetEntity(false, x => x.OrganizationId == addObject.OrganizationId).UserDefaultPassword;
                        user = _userRepository.CreateEntity(
                            new UserDbo()
                            {
                                UserEmail = email,
                                UserRoleId = _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER).Id,
                                UserPassword = defaultPassword,
                                Person = new PersonDbo()
                                {
                                    FirstName = "",
                                    LastName = "",
                                    SecondName = "",
                                },
                                UserMustChangePassword = true,
                            },
                            userId
                        );

                        Dictionary<string, string> replaceData =
                            new() { { ConfigValue.ACTIVATION_LINK, string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_ACTIVATE).Value, user.Id) } };
                        _sendMailService.AddEmailToQueue(
                            EduEmail.REGISTRATION_USER,
                            culture,
                            new EmailAddress() { Email = email, Name = "" },
                            replaceData,
                            addObject.OrganizationId,
                            ""
                        );
                    }
                    foreach (Guid role in addObject.OrganizationRoleId)
                    {
                        _ = _repository.CreateEntity(
                            new UserInOrganizationDbo()
                            {
                                OrganizationId = addObject.OrganizationId,
                                OrganizationRoleId = role,
                                UserId = user.Id
                            },
                            Guid.Empty
                        );
                    }

                    _ = _notificationRepository.CreateEntity(
                        new Model.Tables.Edu.Notification.NotificationDbo()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION).Id,
                            OrganizationId = addObject.OrganizationId,
                            AddDate = DateTime.Now,
                            UserId = user.Id
                        },
                        Guid.Empty
                    );
                }
                else
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ADD_USER_TO_ORGANIZATION, GlobalValue.EMAIL_IS_NOT_VALID, email, 0));
                }
            }
            return new Result<UserInOrganizationDetailDto>() { Data = GetDetail(x => x.UserId == user.Id && x.OrganizationId == addObject.OrganizationId) };
        }

        public override Result<UserInOrganizationDetailDto> UpdateObject(UserInOrganizationUpdateDto update, Guid userId, string culture)
        {
            HashSet<UserInOrganizationDbo> getUserOrganizationRoles = _repository.GetEntities(false, x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId);
            if (getUserOrganizationRoles.Where(x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER).ToList().Count > 0)
            {
                return new Result<UserInOrganizationDetailDto>() { Data = GetDetail(x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId) };
            }
            foreach (UserInOrganizationDbo item in getUserOrganizationRoles)
            {
                if (!update.OrganizationRoleId.Contains(item.Id))
                {
                    _repository.DeleteEntity(item.Id, userId);
                }
            }
            foreach (Guid role in update.OrganizationRoleId)
            {
                UserInOrganizationDbo entity = getUserOrganizationRoles.FirstOrDefault(x => x.Id == role);
                if (entity == null)
                {
                    _ = _repository.CreateEntity(
                        new UserInOrganizationDbo()
                        {
                            OrganizationId = update.OrganizationId,
                            OrganizationRoleId = role,
                            UserId = update.Id
                        },
                        Guid.Empty
                    );
                }
                else if (entity.IsDeleted)
                {
                    _repository.RestoreEntity(entity.Id, userId);
                }
            }
            return new Result<UserInOrganizationDetailDto>() { Data = GetDetail(x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId) };
        }

        public HashSet<OrganizationRoleListDto> GetOrganizationRoles()
        {
            return _convertor.ConvertToWebModel([.. _organizationRoleRepository.GetEntities(false).OrderBy(x => x.Priority)]);
        }

        public override UserInOrganizationDetailDto GetDetail(Expression<Func<UserInOrganizationDbo, bool>> predicate, string culture = "")
        {
            HashSet<UserInOrganizationDbo> getUserOrganizationRoles = _repository.GetEntities(false, predicate);
            UserInOrganizationDetailDto result =
                new()
                {
                    RoleId = getUserOrganizationRoles.Select(x => x.OrganizationRoleId).ToHashSet(),
                    Id = getUserOrganizationRoles.FirstOrDefault().UserId,
                    Role = getUserOrganizationRoles.Select(x => x.OrganizationRole.SystemIdentificator).ToHashSet(),
                };
            return result;
        }

        public UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId)
        {
            UserInOrganizationDbo getAllUserInOrganizations = _repository
                .GetEntities(false, x => x.OrganizationId == _repository.GetOrganizationId(courseId))
                .FirstOrDefault(x =>
                    x.UserId == userId
                    && (
                        x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                    )
                );
            return getAllUserInOrganizations == null
                ? new UserOrganizationRoleDetailDto()
                {
                    IsCourseAdministrator = false,
                    IsCourseEditor = false,
                    IsOrganizationAdministrator = false,
                    IsOrganizationOwner = false,
                    IsLector = _courseLectorRepository.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                }
                : new UserOrganizationRoleDetailDto()
                {
                    IsCourseAdministrator = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                    IsCourseEditor = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                    IsOrganizationAdministrator = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                    IsOrganizationOwner = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                    IsLector = _courseLectorRepository.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                };
        }

        public UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId)
        {
            return new UserOrganizationRoleDetailDto()
            {
                IsCourseAdministrator = false,
                IsCourseEditor = false,
                IsLector = _courseLectorRepository.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                IsOrganizationAdministrator = false,
                IsOrganizationOwner = false,
                IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
            };
        }
    }
}
