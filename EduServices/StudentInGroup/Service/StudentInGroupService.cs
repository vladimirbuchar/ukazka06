using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Base.Sort;
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
using Services.StudentInGroup.Sort;
using Services.StudentInGroup.Validator;
using Services.SystemService.SendMailService.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

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
        ICodeBookRepository<NotificationTypeDbo> codeBookRepository,
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
        private readonly ICodeBookRepository<NotificationTypeDbo> _notificationTypes = codeBookRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IStudentGroupRepository _studentGroupRepository = studentGroupRepository;

        public override async Task<Result> AddObject(StudentInGroupCreateDto addObject, Guid userId, string culture)
        {
            Result<StudentInGroupDetailDto> result = new();
            string email = addObject.UserEmail;

            if (email.IsValidEmail())
            {
                UserDbo user = await _userRepository.GetEntity(false, x => x.UserEmail == email);
                if (user == null)
                {
                    string defaultPassword = (await _organizationSettingRepository
                        .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId))
                        .UserDefaultPassword;
                    _ = await _userRepository.CreateEntity(
                        new UserDbo()
                        {
                            UserEmail = email,
                            Person = new PersonDbo()
                            {
                                FirstName = addObject.FirstName,
                                LastName = addObject.LastName,
                                SecondName = "",
                            },
                            UserRoleId = (await _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER)).Id,
                            UserPassword = defaultPassword.GetHashString()
                        },
                        Guid.Empty
                    );
                    user = await _userRepository.GetEntity(false, x => x.UserEmail == email);

                    Guid studentId = (await _userInOrganizationRepository
                        .CreateEntity(
                            new UserInOrganizationDbo()
                            {
                                OrganizationId = addObject.OrganizationId,
                                OrganizationRoleId = (await _organizationRoleRepository
                                    .GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT)
                                    ).Id,
                                UserId = user.Id
                            },
                            Guid.Empty
                        ))
                        .Id;
                    _ = await _notificationRepository.CreateEntity(
                        new NotificationDbo()
                        {
                            IsNew = true,
                            NotificationTypeId = (await _notificationTypes
                                .GetEntity(false, x => x.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION))
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
                    await _sendMailService.AddEmailToQueue(
                        EduEmail.REGISTRATION_USER,
                        culture,
                        new EmailAddress() { Email = email, Name = "" },
                        replaceData
                    );
                }
                _ = await _repository.CreateEntity(
                    new StudentInGroupDbo()
                    {
                        UserInOrganizationId = (await _userInOrganizationRepository
                            .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId && x.User.UserEmail == email)
                            )
                            .Id,
                        StudentGroupId = addObject.StudentGroupId
                    },
                    Guid.Empty
                );
                List<StudentInGroupCourseTermDbo> getAllTermInGroups = await _studentInGroupCourseTermRepository
                    .GetEntities(false, x => x.StudentGroupId == addObject.StudentGroupId)
                    ;
                foreach (StudentInGroupCourseTermDbo item in getAllTermInGroups)
                {
                    _ = await _courseStudentRepository.CreateEntity(
                        new CourseStudentDbo()
                        {
                            CourseTermId = item.CourseTermId,
                            UserInOrganizationId = (await _userInOrganizationRepository
                                .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId && x.User.UserEmail == email)
                                )
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

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _studentGroupRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<StudentInGroupDbo, bool>> PrepareSqlFilter(StudentInGroupFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentInGroupDbo), "StudentInGroup");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(
                filter.FirstName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.FirstName)
            );
            expression = FilterString(
                filter.SecondName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.SecondName)
            );
            expression = FilterString(
                filter.LastName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.LastName)
            );
            expression = FilterString(
                filter.Email,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail)
            );
            return Expression.Lambda<Func<StudentInGroupDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<StudentInGroupDbo>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentInGroupDbo), "x");
            MemberExpression property = Expression.Property(parameter, nameof(StudentInGroupDbo.UserInOrganization));
            MemberExpression property1 = Expression.Property(property, nameof(StudentInGroupDbo.UserInOrganization.User));
            if (columnName == StudentInGroupSort.FirstName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.FirstName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<StudentInGroupDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            if (columnName == StudentInGroupSort.SecondName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.SecondName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<StudentInGroupDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            if (columnName == StudentInGroupSort.LastName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.LastName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<StudentInGroupDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            if (columnName == StudentInGroupSort.Email.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<StudentInGroupDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
