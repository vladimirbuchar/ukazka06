using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Integration.HttpClient;
using Integration.MailKitIntegration;
using Integration.PdfSharpIntegration;
using Integration.PowerPointIntegration;
using Microsoft.Extensions.DependencyInjection;
using Repository.AnswerRepository;
using Repository.AttendanceStudentRepository;
using Repository.BankOfQuestionRepository;
using Repository.BranchRepository;
using Repository.CertificateRepository;
using Repository.ChatRepository;
using Repository.ClassRoomRepository;
using Repository.CourseLectorRepository;
using Repository.CourseLessonItemRepository;
using Repository.CourseLessonRepository;
using Repository.CourseMaterialRepository;
using Repository.CourseRepository;
using Repository.CourseStudentRepository;
using Repository.CourseTableRepository;
using Repository.CourseTermDateRepository;
using Repository.CourseTermRepository;
using Repository.CourseTestBankOfQuestionRepository;
using Repository.CourseTestEvaluationRepository;
using Repository.CouseStudentMaterialRepository;
using Repository.LicenseChangeRepository;
using Repository.LinkLifeTimeRepository;
using Repository.MessageRepository;
using Repository.NoteRepository;
using Repository.NotificationRepository;
using Repository.OrganizationCultureRepository;
using Repository.OrganizationHoursRepository;
using Repository.OrganizationRepository;
using Repository.OrganizationRoleRepository;
using Repository.OrganizationSettingRepository;
using Repository.PermissionsRepository;
using Repository.QuestionRepository;
using Repository.RoleRepository;
using Repository.RouteRepository;
using Repository.SendEmailRepository;
using Repository.StudentEvaluationRepository;
using Repository.StudentGroupRepository;
using Repository.StudentInGroupCourseTerm;
using Repository.StudentInGroupRepository;
using Repository.StudentTestSummaryAnswerRepository;
using Repository.StudentTestSummaryQuestionRepository;
using Repository.StudentTestSummaryRepository;
using Repository.TestRepository;
using Repository.UserCertificateRepository;
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.Answer.Convertor;
using Services.Answer.Service;
using Services.Answer.Validator;
using Services.BankOfQuestion.Convertor;
using Services.BankOfQuestion.Service;
using Services.BankOfQuestion.Validator;
using Services.Branch.Convertor;
using Services.Branch.Service;
using Services.Branch.Validator;
using Services.Certificate.Convertor;
using Services.Certificate.Service;
using Services.Certificate.Validator;
using Services.Chat.Convertor;
using Services.Chat.Service;
using Services.Chat.Validator;
using Services.ClassRoom.Convertor;
using Services.ClassRoom.Service;
using Services.ClassRoom.Validator;
using Services.CodeBookData.Convertor;
using Services.CodeBookData.Service;
using Services.Course.Convertor;
using Services.Course.Service;
using Services.Course.Validator;
using Services.CourseLesson.Convertor;
using Services.CourseLesson.Service;
using Services.CourseLesson.Validator;
using Services.CourseLessonItem.Convertor;
using Services.CourseLessonItem.Service;
using Services.CourseLessonItem.Validator;
using Services.CourseMaterial.Convertor;
using Services.CourseMaterial.Service;
using Services.CourseMaterial.Validator;
using Services.CourseTerm.Convertor;
using Services.CourseTerm.Service;
using Services.CourseTerm.Validator;
using Services.CourseTermStudent.Convertor;
using Services.CourseTermStudent.Service;
using Services.CourseTermTimeTable.Convertor;
using Services.CourseTermTimeTable.Service;
using Services.CourseTestEvaluation.Convertor;
using Services.CourseTestEvaluation.Service;
using Services.CourseTestEvaluation.Validator;
using Services.HangfireJob;
using Services.Message.Convertor;
using Services.Message.Service;
using Services.Message.Validator;
using Services.Note.Convertor;
using Services.Note.Service;
using Services.Notification.Convertor;
using Services.Notification.Service;
using Services.Organization.Convertor;
using Services.Organization.Service;
using Services.Organization.Validator;
using Services.OrganizationCulture.Convertor;
using Services.OrganizationCulture.Service;
using Services.OrganizationCulture.Validator;
using Services.OrganizationRole.Convertor;
using Services.OrganizationRole.Service;
using Services.OrganizationSetting.Convertor;
using Services.OrganizationSetting.Service;
using Services.OrganizationSetting.Validator;
using Services.OrganizationStudyHour.Convertor;
using Services.OrganizationStudyHour.Service;
using Services.OrganizationStudyHour.Validator;
using Services.Page.Service;
using Services.Question.Convertor;
using Services.Question.Service;
using Services.Question.Validator;
using Services.Route.Convertor;
using Services.Route.Service;
using Services.Route.Validator;
using Services.Setup.Service;
using Services.StudentAttendance.Service;
using Services.StudentEvaluation.Service;
using Services.StudentGroup.Convertor;
using Services.StudentGroup.Service;
using Services.StudentGroup.Validator;
using Services.StudentInGroup.Convertor;
using Services.StudentInGroup.Service;
using Services.StudentInGroup.Validator;
using Services.SystemService.License.Service;
using Services.SystemService.SendMailService.Convertor;
using Services.SystemService.SendMailService.Service;
using Services.Test.Convertor;
using Services.Test.Service;
using Services.UserInOrganization.Convertor;
using Services.UserInOrganization.Service;
using Services.UserInOrganization.Validator;

namespace Services
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

        [System.Obsolete]
        public static void RegistrationStudentInGroup(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentInGroupRepository, StudentInGroupRepository>();
            _ = service.AddScoped<IStudentInGroupConvertor, StudentInGroupConvertor>();
            _ = service.AddScoped<IStudentInGroupValidator, StudentInGroupValidator>();
            _ = service.AddScoped<IStudentInGroupService, StudentInGroupService>();
            _ = service.AddScoped<IStudentInGroupCourseTermRepository, StudentInGroupCourseTermRepository>();
        }

        [System.Obsolete]
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

        [System.Obsolete]
        public static void RegistrationOrganizationStudyHour(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationStudyHourService, OrganizationStudyHourService>();
            _ = service.AddScoped<IOrganizationStudyHourConvertor, OrganizationStudyHourConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourValidator, OrganizationStudyHourValidator>();
            _ = service.AddScoped<IOrganizationStudyHourRepository, OrganizationStudyHourRepository>();
        }

        public static void RegistrationCodeBook(this IServiceCollection service)
        {
            _ = service.AddScoped<ICodebookService, CodeBookRepository>();
            _ = service.AddScoped(typeof(ICodeBookRepository<>), typeof(CodeBookRepository<>));
            _ = service.AddScoped<ICodeBookConvertor, CodeBookConvertor>();
        }

        public static void RegisterEmail(this IServiceCollection service)
        {
            _ = service.AddScoped<ISendEmailRepository, SendEmailRepository>();
            _ = service.AddScoped<ISendMailService, SendMailService>();
            _ = service.AddScoped<ISendMailConvertor, SendMailConvertor>();
            _ = service.AddScoped<IPowerPointIntegration, PowerPointIntegration>();
        }

        public static void RegisterIntegration(this IServiceCollection service)
        {
            _ = service.AddScoped<IMailKitIntegration, MailKitIntegration>();
            _ = service.AddScoped<IHttpClient, HttpClient>();
        }

        [System.Obsolete]
        public static void RegistrationUser(this IServiceCollection service)
        {
            _ = service.AddScoped<IUserRepository, UserRepository>();

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

        [System.Obsolete]
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

        [System.Obsolete]
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

        [System.Obsolete]
        public static void RegistrationClassRoom(this IServiceCollection service)
        {
            _ = service.AddScoped<IClassRoomService, ClassRoomService>();
            _ = service.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            _ = service.AddScoped<IClassRoomConvertor, ClasssRoomConvertor>();
            _ = service.AddScoped<IClassRoomValidator, ClassRoomValidator>();
        }

        [System.Obsolete]
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

        [System.Obsolete]
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
            _ = service.AddScoped<IMessageService, MessageService>();
            _ = service.AddScoped<IMessageConvertor, MessageConvertor>();
            _ = service.AddScoped<IMessageRepository, MessageRepository>();
            _ = service.AddScoped<IMessageValidator, MessageValidator>();
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

        [System.Obsolete]
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
