using Core.Base.Repository.CodeBookRepository;
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
using Repository.CourseLectorRepository;
using Repository.CourseStudentRepository;
using Repository.NotificationRepository;
using Repository.OrganizationRoleRepository;
using Repository.OrganizationSettingRepository;
using Repository.RoleRepository;
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.OrganizationRole.Dto;
using Services.SystemService.SendMailService.Service;
using Services.UserInOrganization.Convertor;
using Services.UserInOrganization.Dto;
using Services.UserInOrganization.Filter;
using Services.UserInOrganization.Sort;
using Services.UserInOrganization.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.UserInOrganization.Service
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
            UserInOrganizationUpdateDto,
            UserInOrganizationFilter
        >(organizationRepository, organizationConvertor, validator),
            IUserInOrganizationService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly List<NotificationTypeDbo> _notificationTypes = notificationTypeCodebook.GetEntities(false).Result;
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
                        string defaultPassword = _organizationSettingRepository
                            .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId)
                            .UserDefaultPassword;
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
                        new NotificationDbo()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes
                                .FirstOrDefault(x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION)
                                .Id,
                            OrganizationId = addObject.OrganizationId,
                            AddDate = DateTime.Now,
                            UserId = user.Id
                        },
                        Guid.Empty
                    );
                }
                else
                {
                    result.AddResultStatus(
                        new ValidationMessage(MessageType.ERROR, MessageCategory.ADD_USER_TO_ORGANIZATION, MessageItem.EMAIL_IS_NOT_VALID, email, 0)
                    );
                }
            }
            return new Result<UserInOrganizationDetailDto>()
            {
                Data = GetDetail(x => x.UserId == user.Id && x.OrganizationId == addObject.OrganizationId)
            };
        }

        public override Result<UserInOrganizationDetailDto> UpdateObject(
            UserInOrganizationUpdateDto update,
            Guid userId,
            string culture,
            Result<UserInOrganizationDetailDto> result = null
        )
        {
            List<UserInOrganizationDbo> getUserOrganizationRoles = _repository
                .GetEntities(false, x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId)
                .Result;
            if (getUserOrganizationRoles.Where(x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER).ToList().Count > 0)
            {
                return new Result<UserInOrganizationDetailDto>()
                {
                    Data = GetDetail(x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId)
                };
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
            return new Result<UserInOrganizationDetailDto>()
            {
                Data = GetDetail(x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId)
            };
        }

        public List<OrganizationRoleListDto> GetOrganizationRoles()
        {
            return _convertor.ConvertToWebModel([.. _organizationRoleRepository.GetEntities(false, null, null, x => x.Priority).Result]);
        }

        public override UserInOrganizationDetailDto GetDetail(Expression<Func<UserInOrganizationDbo, bool>> predicate, string culture = "")
        {
            List<UserInOrganizationDbo> getUserOrganizationRoles = _repository.GetEntities(false, predicate).Result;
            UserInOrganizationDetailDto result =
                new()
                {
                    RoleId = getUserOrganizationRoles.Select(x => x.OrganizationRoleId).ToList(),
                    Id = getUserOrganizationRoles.FirstOrDefault().UserId,
                    Role = getUserOrganizationRoles.Select(x => x.OrganizationRole.SystemIdentificator).ToList(),
                };
            return result;
        }

        public UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId)
        {
            UserInOrganizationDbo getAllUserInOrganizations = _repository
                .GetEntities(false, x => x.OrganizationId == _repository.GetOrganizationId(courseId))
                .Result.FirstOrDefault(x =>
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
                    IsLector =
                        _courseLectorRepository
                            .GetEntities(false, x => x.UserInOrganization.UserId == userId)
                            .Result.FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                }
                : new UserOrganizationRoleDetailDto()
                {
                    IsCourseAdministrator =
                        getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                    IsCourseEditor = getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                    IsOrganizationAdministrator =
                        getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                    IsOrganizationOwner =
                        getAllUserInOrganizations.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                    IsLector =
                        _courseLectorRepository
                            .GetEntities(false, x => x.UserInOrganization.UserId == userId)
                            .Result.FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                };
        }

        public UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId)
        {
            return new UserOrganizationRoleDetailDto()
            {
                IsCourseAdministrator = false,
                IsCourseEditor = false,
                IsLector =
                    _courseLectorRepository
                        .GetEntities(false, x => x.UserInOrganization.UserId == userId)
                        .Result.FirstOrDefault(x => x.Id == courseId) != null,
                IsOrganizationAdministrator = false,
                IsOrganizationOwner = false,
                IsStudent = _courseStudentRepository.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
            };
        }

        protected override Expression<Func<UserInOrganizationDbo, bool>> PrepareSqlFilter(UserInOrganizationFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(UserInOrganizationDbo), "userInOrganization");
            Expression expression = Expression.Constant(true);
            expression = FilterString(
                filter.FirstName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.FirstName)
            );
            expression = FilterString(
                filter.SecondName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.SecondName)
            );
            expression = FilterString(
                filter.LastName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.LastName)
            );
            expression = FilterString(
                filter.UserEmail,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.UserEmail)
            );
            expression = FilterString(
                filter.UserRole,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.OrganizationRole),
                nameof(UserInOrganizationDbo.OrganizationRole.SystemIdentificator)
            );
            return Expression.Lambda<Func<UserInOrganizationDbo, bool>>(expression, parameter);
        }

        protected override Expression<Func<UserInOrganizationDbo, object>> PrepareSort(string columnName, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(UserInOrganizationDbo), "x");
            MemberExpression property = Expression.Property(parameter, nameof(UserInOrganizationDbo.User));

            if (columnName == UserInOrganizationSort.FirstName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.FirstName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return lambda;
            }
            if (columnName == UserInOrganizationSort.SecondName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.SecondName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return lambda;
            }
            if (columnName == UserInOrganizationSort.LastName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.LastName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return lambda;
            }
            if (columnName == UserInOrganizationSort.UserEmail.ToString())
            {
                MemberExpression property2 = Expression.Property(property, nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return lambda;
            }
            if (columnName == UserInOrganizationSort.UserRole.ToString())
            {
                MemberExpression role = Expression.Property(parameter, nameof(UserInOrganizationDbo.OrganizationRole));
                MemberExpression roleName = Expression.Property(role, nameof(UserInOrganizationDbo.OrganizationRole.SystemIdentificator));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(roleName, typeof(object)),
                    parameter
                );
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
