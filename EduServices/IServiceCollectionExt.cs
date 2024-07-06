using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using EduRepository.AnswerRepository;
using EduRepository.AttendanceStudentRepository;
using EduRepository.BankOfQuestionRepository;
using EduRepository.BranchRepository;
using EduRepository.CertificateRepository;
using EduRepository.ChatRepository;
using EduRepository.ClassRoomRepository;
using EduRepository.CourseLectorRepository;
using EduRepository.CourseLessonItemRepository;
using EduRepository.CourseLessonRepository;
using EduRepository.CourseMaterialRepository;
using EduRepository.CourseRepository;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTableRepository;
using EduRepository.CourseTermDateRepository;
using EduRepository.CourseTermRepository;
using EduRepository.CourseTestBankOfQuestionRepository;
using EduRepository.CourseTestEvaluationRepository;
using EduRepository.CouseStudentMaterialRepository;
using EduRepository.EmailRepository;
using EduRepository.LicenseChangeRepository;
using EduRepository.LinkLifeTimeRepository;
using EduRepository.NoteRepository;
using EduRepository.NotificationRepository;
using EduRepository.OrganizationCultureRepository;
using EduRepository.OrganizationHoursRepository;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationRoleRepository;
using EduRepository.OrganizationSettingRepository;
using EduRepository.PermissionsRepository;
using EduRepository.QuestionRepository;
using EduRepository.RoleRepository;
using EduRepository.RouteRepository;
using EduRepository.SendMessageRepository;
using EduRepository.StudentEvaluationRepository;
using EduRepository.StudentGroupRepository;
using EduRepository.StudentInGroupCourseTerm;
using EduRepository.StudentInGroupRepository;
using EduRepository.StudentTestSummaryAnswerRepository;
using EduRepository.StudentTestSummaryQuestionRepository;
using EduRepository.StudentTestSummaryRepository;
using EduRepository.TestRepository;
using EduRepository.UserCertificateRepository;
using EduRepository.UserInOrganizationRepository;
using EduRepository.UserRepository;
using EduServices.Answer.Convertor;
using EduServices.Answer.Service;
using EduServices.Answer.Validator;
using EduServices.BankOfQuestion.Convertor;
using EduServices.BankOfQuestion.Service;
using EduServices.BankOfQuestion.Validator;
using EduServices.Branch.Convertor;
using EduServices.Branch.Service;
using EduServices.Branch.Validator;
using EduServices.Certificate.Convertor;
using EduServices.Certificate.Service;
using EduServices.Certificate.Validator;
using EduServices.Chat.Convertor;
using EduServices.Chat.Service;
using EduServices.Chat.Validator;
using EduServices.ClassRoom.Convertor;
using EduServices.ClassRoom.Service;
using EduServices.ClassRoom.Validator;
using EduServices.CodeBookData.Convertor;
using EduServices.CodeBookData.Service;
using EduServices.Course.Convertor;
using EduServices.Course.Service;
using EduServices.Course.Validator;
using EduServices.CourseLesson.Convertor;
using EduServices.CourseLesson.Service;
using EduServices.CourseLesson.Validator;
using EduServices.CourseLessonItem.Convertor;
using EduServices.CourseLessonItem.Service;
using EduServices.CourseLessonItem.Validator;
using EduServices.CourseMaterial.Convertor;
using EduServices.CourseMaterial.Service;
using EduServices.CourseMaterial.Validator;
using EduServices.CourseTerm.Convertor;
using EduServices.CourseTerm.Service;
using EduServices.CourseTerm.Validator;
using EduServices.CourseTermStudent.Convertor;
using EduServices.CourseTermStudent.Service;
using EduServices.CourseTermTimeTable.Convertor;
using EduServices.CourseTermTimeTable.Service;
using EduServices.CourseTestEvaluation.Convertor;
using EduServices.CourseTestEvaluation.Service;
using EduServices.CourseTestEvaluation.Validator;
using EduServices.HangfireJob;
using EduServices.Note.Convertor;
using EduServices.Note.Service;
using EduServices.Notification.Convertor;
using EduServices.Notification.Service;
using EduServices.Organization.Convertor;
using EduServices.Organization.Service;
using EduServices.Organization.Validator;
using EduServices.OrganizationCulture.Convertor;
using EduServices.OrganizationCulture.Service;
using EduServices.OrganizationCulture.Validator;
using EduServices.OrganizationRole.Convertor;
using EduServices.OrganizationRole.Service;
using EduServices.OrganizationSetting.Convertor;
using EduServices.OrganizationSetting.Service;
using EduServices.OrganizationSetting.Validator;
using EduServices.OrganizationStudyHour.Convertor;
using EduServices.OrganizationStudyHour.Service;
using EduServices.OrganizationStudyHour.Validator;
using EduServices.Page.Service;
using EduServices.Permissions.Convertor;
using EduServices.Permissions.Service;
using EduServices.Permissions.Validator;
using EduServices.Question.Convertor;
using EduServices.Question.Service;
using EduServices.Question.Validator;
using EduServices.Route.Convertor;
using EduServices.Route.Service;
using EduServices.Route.Validator;
using EduServices.SendMessage.Convertor;
using EduServices.SendMessage.Service;
using EduServices.SendMessage.Validator;
using EduServices.Setup.Service;
using EduServices.StudentAttendance.Service;
using EduServices.StudentEvaluation.Service;
using EduServices.StudentGroup.Convertor;
using EduServices.StudentGroup.Service;
using EduServices.StudentGroup.Validator;
using EduServices.StudentInGroup.Convertor;
using EduServices.StudentInGroup.Service;
using EduServices.StudentInGroup.Validator;
using EduServices.SystemService.License.Service;
using EduServices.SystemService.SendMailService;
using EduServices.Test.Convertor;
using EduServices.Test.Service;
using EduServices.User.Convertor;
using EduServices.User.Service;
using EduServices.User.Validator;
using EduServices.UserInOrganization.Convertor;
using EduServices.UserInOrganization.Service;
using EduServices.UserInOrganization.Validator;
using EduServices.UserProfile.Convertor;
using EduServices.UserProfile.Service;
using Integration.HttpClient;
using Integration.MailKitIntegration;
using Integration.PdfSharpIntegration;
using Integration.PowerPointIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace EduServices
{
    public static class IServiceCollectionExt
    {
        public static void RegistrationCourseTestEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTestEvaluationService, CourseTestEvaluationService>();
            _ = service.AddScoped<ICourseTestEvaluationConvertor, CourseTestEvaluationConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationRepository, CourseTestEvaluationRepository>();
            _ = service.AddScoped<ICourseTestEvaluationValidator, CourseTestEvaluationValidator>();
        }

        public static void RegistrationStudentInGroup(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentInGroupRepository, StudentInGroupRepository>();
            _ = service.AddScoped<IStudentInGroupConvertor, StudentInGroupConvertor>();
            _ = service.AddScoped<IStudentInGroupValidator, StudentInGroupValidator>();
            _ = service.AddScoped<IStudentInGroupService, StudentInGroupService>();
            _ = service.AddScoped<IStudentInGroupCourseTermRepository, StudentInGroupCourseTermRepository>();
        }

        public static void RegistrationOrganizationCulture(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationCultureService, OrganizationCultureService>();
            _ = service.AddScoped<IOrganizationCultureConvertor, OrganizationCultureConvertor>();
            _ = service.AddScoped<IOrganizationCultureValidator, OrganizationCultureValidator>();
            _ = service.AddScoped<IOrganizationCultureRepository, OrganizationCultureRepository>();
        }

        public static void RegistrationCourseTermDate(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermTimeTableConvertor, CourseTermTimeTableConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableService, CourseTermTimeTableService>();
            _ = service.AddScoped<ICourseTermDateRepository, CourseTermDateRepository>();
        }

        public static void RegistrationOrganizationStudyHour(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationStudyHourService, OrganizationStudyHourService>();
            _ = service.AddScoped<IOrganizationStudyHourConvertor, OrganizationStudyHourConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourValidator, OrganizationStudyHourValidator>();
            _ = service.AddScoped<IOrganizationStudyHourRepository, OrganizationStudyHourRepository>();
        }

        public static void RegistrationCodeBook(this IServiceCollection service)
        {
            _ = service.AddScoped<ICodeBookService, CodeBookService>();
            _ = service.AddScoped(typeof(ICodeBookRepository<>), typeof(CodeBookRepository<>));
            _ = service.AddScoped<ICodeBookConvertor, CodeBookConvertor>();
        }

        public static void RegisterEmail(this IServiceCollection service)
        {
            _ = service.AddScoped<IEmailRepository, EmailRepository>();
            _ = service.AddScoped<ISendMailService, SendMailService>();
            _ = service.AddScoped<IPowerPointIntegration, PowerPointIntegration>();
        }

        public static void RegisterIntegration(this IServiceCollection service)
        {
            _ = service.AddScoped<IMailKitIntegration, MailKitIntegration>();
            _ = service.AddScoped<IHttpClient, HttpClient>();
        }

        public static void RegistrationUser(this IServiceCollection service)
        {
            _ = service.AddScoped<IUserService, UserService>();
            _ = service.AddScoped<IUserRepository, UserRepository>();
            _ = service.AddScoped<IUserConvertor, UserConvertor>();
            _ = service.AddScoped<IUserValidator, UserValidator>();
        }

        public static void RegistrationRole(this IServiceCollection service)
        {
            _ = service.AddScoped<IRoleRepository, RoleRepository>();
        }

        public static void RegistrationOrganizationRole(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationRoleService, OrganizationRoleService>();
            _ = service.AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();
            _ = service.AddScoped<IOrganizationRoleConvertor, OrganizationRoleConvertor>();
        }

        public static void RegistrationOrganizationSetting(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationSettingRepository, OrganizationSettingRepository>();
            _ = service.AddScoped<IOrganizationSettingService, OrganizationSettingService>();
            _ = service.AddScoped<IOrganizationSettingConvertor, OrganizationSettingConvertor>();
            _ = service.AddScoped<IOrganizationSettingValidator, OrganizationSettingValidator>();
        }

        public static void RegistrationOrganization(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationRepository, OrganizationRepository>();
            _ = service.AddScoped<IOrganizationService, OrganizationService>();
            _ = service.AddScoped<IOrganizationConvertor, OrganizationConvertor>();
            _ = service.AddScoped<IOrganizationValidator, OrganizationValidator>();
        }

        public static void RegistrationIUserInOrganization(this IServiceCollection service)
        {
            _ = service.AddScoped<IUserInOrganizationService, UserInOrganizationService>();
            _ = service.AddScoped<IUserInOrganizationConvertor, UserInOrganizationConvertor>();
            _ = service.AddScoped<IUserInOrganizationValidator, UserInOrganizationValidator>();
            _ = service.AddScoped<IUserInOrganizationRepository, UserInOrganizationRepository>();
        }

        public static void RegisterLicense(this IServiceCollection service)
        {
            _ = service.AddScoped<ILicenseService, LicenseService>();
            _ = service.AddScoped<ILicenseChangeRepository, LicenseChangeRepository>();
        }

        public static void RegisterBranch(this IServiceCollection service)
        {
            _ = service.AddScoped<IBranchRepository, BranchRepository>();
            _ = service.AddScoped<IBranchService, BranchService>();
            _ = service.AddScoped<IBranchConvertor, BranchConvertor>();
            _ = service.AddScoped<IBranchValidator, BranchValidator>();
        }

        public static void RegistrationCourse(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseRepository, CourseRepository>();
            _ = service.AddScoped<ICourseService, CourseService>();
            _ = service.AddScoped<ICourseConvertor, CourseConvertor>();
            _ = service.AddScoped<ICourseValidator, CourseValidator>();
        }

        public static void RegistrationClassRoom(this IServiceCollection service)
        {
            _ = service.AddScoped<IClassRoomService, ClassRoomService>();
            _ = service.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            _ = service.AddScoped<IClassRoomConvertor, ClasssRoomConvertor>();
            _ = service.AddScoped<IClassRoomValidator, ClassRoomValidator>();
        }

        public static void RegistrationCourseTerm(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermConvertor, CourseTermConvertor>();
            _ = service.AddScoped<ICourseTermService, CourseTermService>();
            _ = service.AddScoped<ICourseTermRepository, CourseTermRepository>();
            _ = service.AddScoped<ICourseTermValidator, CourseTermValidator>();
        }

        public static void RegistrationCourseLector(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLectorRepository, CourseLectorRepository>();
        }

        public static void RegistrionCourseStudent(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermStudentService, CourseTermStudentService>();
            _ = service.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            _ = service.AddScoped<ICourseTermStudentConvertor, CourseTermStudentConvertor>();
        }

        public static void RegistrationCourseLesson(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonService, CourseLessonService>();
            _ = service.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
            _ = service.AddScoped<ICourseLessonConvertor, CourseLessonConvertor>();
            _ = service.AddScoped<ICourseLessonValidator, CourseLessonValidator>();
        }

        public static void RegistrationCourseLessonItem(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonItemService, CourseLessonItemService>();
            _ = service.AddScoped<ICourseLessonItemRepository, CourseLessonItemRepository>();
            _ = service.AddScoped<ICourseLessonItemConvertor, CourseLessonItemConvertor>();
            _ = service.AddScoped<ICourseLessonItemValidator, CourseLessonItemValidator>();
        }

        public static void RegistratioBankOfQuestion(this IServiceCollection service)
        {
            _ = service.AddScoped<IBankOfQuestionConvertor, BankOfQuestionConvertor>();
            _ = service.AddScoped<IBankOfQuestionService, BankOfQuestionService>();
            _ = service.AddScoped<IBankOfQuestionRepository, BankOfQuestionRepository>();
            _ = service.AddScoped<IBankOfQuestionValidator, BankOfQuestionValidator>();
        }

        public static void RegistrationQuestion(this IServiceCollection service)
        {
            _ = service.AddScoped<IQuestionConvertor, QuestionConvertor>();
            _ = service.AddScoped<IQuestionService, QuestionService>();
            _ = service.AddScoped<IQuestionRepository, QuestionRepository>();
            _ = service.AddScoped<IQuestionValidator, QuestionValidator>();
        }

        public static void RegistrationAnswer(this IServiceCollection service)
        {
            _ = service.AddScoped<IAnswerConvertor, AnswerConvertor>();
            _ = service.AddScoped<IAnswerService, AnswerService>();
            _ = service.AddScoped<IAnswerRepository, AnswerRepository>();
            _ = service.AddScoped<IAnswerValidator, AnswerValidator>();
        }

        public static void RegisterNotification(this IServiceCollection service)
        {
            _ = service.AddScoped<INotificationService, NotificationService>();
            _ = service.AddScoped<INotificationRepository, NotificationRepository>();
            _ = service.AddScoped<INotificationConvertor, NotificationConvertor>();
        }

        public static void RegisterFileUpload(this IServiceCollection service)
        {
            _ = service.AddScoped(typeof(IFileUploadRepository<>), typeof(FileUploadRepository<>));
        }

        public static void RegisterTest(this IServiceCollection service)
        {
            _ = service.AddScoped<ITestService, TestService>();
            _ = service.AddScoped<ITestRepository, TestRepository>();
            _ = service.AddScoped<ITestConvertor, TestConvertor>();
            _ = service.AddScoped<ICourseTestBankOfQuestionRepository, CourseTestBankOfQuestionRepository>();
        }

        public static void RegisterPage(this IServiceCollection service)
        {
            _ = service.AddScoped<IPageService, PageService>();
        }

        public static void RegisterLifeTime(this IServiceCollection service)
        {
            _ = service.AddScoped<ILinkLifeTimeRepository, LinkLifeTimeRepository>();
        }

        public static void RegisterCertificate(this IServiceCollection service)
        {
            _ = service.AddScoped<ICertificateService, CertificateService>();
            _ = service.AddScoped<ICertificateRepository, CertificateRepository>();
            _ = service.AddScoped<ICertificateConvertor, CertificateConvertor>();
            _ = service.AddScoped<ICertificateValidator, CertificateValidator>();
            _ = service.AddScoped<IUserCertificateRepository, UserCertificateRepository>();
        }

        public static void RegisterPdf(this IServiceCollection service)
        {
            _ = service.AddScoped<IPdfSharpIntegration, PdfSharpIntegration>();
        }

        public static void RegisterSendMessage(this IServiceCollection service)
        {
            _ = service.AddScoped<ISendMessageService, SendMessageService>();
            _ = service.AddScoped<ISendMessageConvertor, SendMessageConvertor>();
            _ = service.AddScoped<ISendMessageRepository, SendMessageRepository>();
            _ = service.AddScoped<ISendMessageValidator, SendMessageValidator>();
        }

        public static void RegisterStudentGroup(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentGroupConvertor, StudentGroupConvertor>();
            _ = service.AddScoped<IStudentGroupService, StudentGroupService>();
            _ = service.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
            _ = service.AddScoped<IStudentGroupValidator, StudentGroupValidator>();
        }

        public static void RegisterCourseMaterial(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseMaterialRepository, CourseMaterialRepository>();
            _ = service.AddScoped<ICourseMaterialConvertor, CourseMaterialConvertor>();
            _ = service.AddScoped<ICourseMaterialService, CourseMaterialService>();
            _ = service.AddScoped<ICourseMaterialValidator, CourseMaterialValidator>();
        }

        public static void RegisterNote(this IServiceCollection service)
        {
            _ = service.AddScoped<INoteService, NoteService>();
            _ = service.AddScoped<INoteRepository, NoteRepository>();
            _ = service.AddScoped<INoteConvertor, NoteConvertor>();
        }

        public static void RegisterCourseTable(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTableRepository, CourseTableRepository>();
        }

        public static void RegisterChat(this IServiceCollection service)
        {
            _ = service.AddScoped<IChatConvertor, ChatConvertor>();
            _ = service.AddScoped<IChatService, ChatService>();
            _ = service.AddScoped<IChatRepository, ChatRepository>();
            _ = service.AddScoped<IChatValidator, ChatValidator>();
        }

        public static void RegistrationAttendanceStudent(this IServiceCollection service)
        {
            _ = service.AddScoped<IAttendanceStudentRepository, AttendanceStudentRepository>();
            _ = service.AddScoped<IStudentAttendanceService, StudentAttendanceService>();
        }

        public static void RegistrationCouseStudentMaterial(this IServiceCollection service)
        {
            _ = service.AddScoped<ICouseStudentMaterialRepository, CouseStudentMaterialRepository>();
        }

        public static void RegistrationStudentEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentEvaluationRepository, StudentEvaluationRepository>();
            _ = service.AddScoped<IStudentEvaluationService, StudentEvaluationService>();
        }

        public static void RegistrationStudentTestSummary(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentTestSummaryRepository, StudentTestSummaryRepository>();
        }

        public static void RegistrationStudentTestSummaryQuestion(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentTestSummaryQuestionRepository, StudentTestSummaryQuestionRepository>();
        }

        public static void RegistrationIStudentTestSummaryAnswer(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerRepository>();
        }

        public static void RegistrationUserProfile(this IServiceCollection service)
        {
            _ = service.AddScoped<IUserProfileService, UserProfileService>();
            _ = service.AddScoped<IUserProfileConvertor, UserProfileConvertor>();

        }
        public static void RegistrationRoute(this IServiceCollection service)
        {
            _ = service.AddScoped<IRouteRepository, RouteRepository>();
            _ = service.AddScoped<IRouteService, RouteService>();
            _ = service.AddScoped<IRouteConvertor, RouteConvertor>();
            _ = service.AddScoped<IRouteValidator, RouteValidator>();
        }

        public static void RegistrationPermissions(this IServiceCollection service)
        {
            _ = service.AddScoped<IPermissionsRepository, PermissionsRepository>();
            _ = service.AddScoped<IPermissionsService, PermissionsService>();
            _ = service.AddScoped<IPermissionsConvertor, PermissionsConvertor>();
            _ = service.AddScoped<IPermissionsValidator, PermissionsValidator>();
        }
        public static void RegistrationSetup(this IServiceCollection service)
        {
            _ = service.AddScoped<ISetupService, SetupService>();
        }
        public static void RegisterHangfireJob(this IServiceCollection service)
        {
            _ = service.AddScoped<SendEmailJob>();
        }
    }
}
