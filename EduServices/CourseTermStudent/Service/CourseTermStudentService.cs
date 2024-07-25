using Core.Base.Filter;
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
using System.Threading.Tasks;

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
        private readonly ICodeBookRepository<NotificationTypeDbo> _notificationTypes = codeBooService;
        private readonly IOrganizationSettingRepository _organizationSettingRepository = organizationSettingRepository;
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;

        public override async Task<Result> AddObject(CourseTermStudentCreateDto addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                string email = addObject.UserEmail;

                if (email.IsValidEmail())
                {
                    UserDbo user = await _userRepository.GetEntity(false, x => x.UserEmail == email);
                    if (user == null)
                    {
                        string defaultPassword = (await _organizationSettingRepository
                            .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId))
                            .UserDefaultPassword;
                        user = await _userRepository.CreateEntity(
                            new UserDbo()
                            {
                                UserEmail = email,
                                UserRoleId = (await _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER)).Id,
                                UserPassword = defaultPassword,
                                Person = new PersonDbo() { FirstName = addObject.FirstName, LastName = addObject.LastName }
                            },
                            userId
                        );

                        _ = await _userInOrganizationRepository.CreateEntity(
                            new UserInOrganizationDbo()
                            {
                                OrganizationId = addObject.OrganizationId,
                                OrganizationRoleId = (await _organizationRoleRepository
                                    .GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT))
                                    .Id,
                                UserId = user.Id
                            },
                            userId
                        );

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
                        await _sendMailService.AddEmailToQueue(
                            EduEmail.REGISTRATION_USER,
                            culture,
                            new EmailAddress() { Email = email, Name = "" },
                            replaceData,
                            addObject.OrganizationId,
                            ""
                        );
                    }
                    if ((await _repository.GetStudentCourse(user.Id, false)).FirstOrDefault(x => x.CourseTermId == addObject.CourseTermId) == null)
                    {
                        _ = await _repository.CreateEntity(
                            new CourseStudentDbo()
                            {
                                CourseTermId = addObject.CourseTermId,
                                UserInOrganizationId = (await _userInOrganizationRepository
                                    .GetEntity(false, x => x.OrganizationId == addObject.OrganizationId && x.User.UserEmail == email))
                                    .Id
                            },
                            userId
                        );

                        _ = await _notificationRepository.CreateEntity(
                            new NotificationDbo()
                            {
                                IsNew = true,
                                NotificationTypeId = (await _notificationTypes
                                    .GetEntity(false, x => x.SystemIdentificator == NotificationType.ADD_STUDENT_TO_COURSE_TERM))
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

        public async Task<List<CourseTermStudentListDto>> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return await _convertor.ConvertToWebModel(await _repository.GetEntities(false, x => x.CourseTermId == courseTermId), string.Empty);
        }
    }
}
