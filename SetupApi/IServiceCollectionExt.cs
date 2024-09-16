using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
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
using Repository.EmailRepository;
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
using SetupService.CheckUser.Command;
using SetupService.CreateAdministratorUser.Command;
using SetupService.GetAllEndpoints.Command;

namespace SetupApi
{
    public static class IServiceCollectionExt
    {
        public static void RegistrationCourseTestEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTestEvaluationRepository, CourseTestEvaluationRepository>();
            _ = service.AddScoped<ICourseTestEvaluationCreateConvertor, CourseTestEvaluationCreateConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationCreateService, CourseTestEvaluationCreateService>();
            _ = service.AddScoped<ICourseTestEvaluationCreateValidator, CourseTestEvaluationCreateValidator>();
            _ = service.AddScoped<ICourseTestEvaluationDeleteService, CourseTestEvaluationDeleteService>();
            _ = service.AddScoped<ICourseTestEvaluationListConvertor, CourseTestEvaluationListConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationListService, CourseTestEvaluationListService>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateConvertor, CourseTestEvaluationUpdateConvertor>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateService, CourseTestEvaluationUpdateService>();
            _ = service.AddScoped<ICourseTestEvaluationUpdateValidator, CourseTestEvaluationUpdateValidator>();
            _ = service.AddScoped<ILectorCreateConvertor, LectorCreateConvertor>();
            _ = service.AddScoped<ILectorCreateService, LectorCreateService>();
            _ = service.AddScoped<ILectorCreateValidator, LectorCreateValidator>();
            _ = service.AddScoped<ICourseTermTimeTableRestoreService, CourseTermTimeTableRestoreService>();
        }


        public static void RegistrationStudentInGroup(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentInGroupRepository, StudentInGroupRepository>();
            _ = service.AddScoped<IStudentInGroupCreateService, StudentInGroupCreateService>();
            _ = service.AddScoped<IStudentInGroupCreateValidator, StudentInGroupCreateValidator>();
            _ = service.AddScoped<IStudentInGroupDeleteService, StudentInGroupDeleteService>();
            _ = service.AddScoped<IStudentInGroupListConvertor, StudentInGroupListConvertor>();
            _ = service.AddScoped<IStudentInGroupListService, StudentInGroupListService>();

            _ = service.AddScoped<ICourseTermStudentRestoreService, CourseTermStudentRestoreService>();
            _ = service.AddScoped<IStudentInGroupCourseTermRepository, StudentInGroupCourseTermRepository>();
        }


        public static void RegistrationOrganizationCulture(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationCultureRepository, OrganizationCultureRepository>();
            _ = service.AddScoped<IOrganizationCultureCreateService, OrganizationCultureCreateService>();
            _ = service.AddScoped<IOrganizationCultureCreateConvertor, OrganizationCultureCreateConvertor>();
            _ = service.AddScoped<IOrganizationCultureCreateValidator, OrganizationCultureCreateValidator>();
            _ = service.AddScoped<IOrganizationCultureListService, OrganizationCultureListService>();
            _ = service.AddScoped<IOrganizationCultureListConvertor, OrganizationCultureListConvertor>();
            _ = service.AddScoped<IOrganizationCultureUpdateService, OrganizationCultureUpdateService>();
            _ = service.AddScoped<IOrganizationCultureUpdateConvertor, OrganizationCultureUpdateConvertor>();
            _ = service.AddScoped<IOrganizationCultureUpdateValidator, OrganizationCultureUpdateValidator>();
            _ = service.AddScoped<IOrganizationCultureDeleteService, OrganizationCultureDeleteService>();
            _ = service.AddScoped<IOrganizationCultureRestoreService, OrganizationCultureRestoreService>();
        }


        public static void RegistrationCourseTermDate(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermTimeTableUpdateService, CourseTermTimeTableUpdateService>();
            _ = service.AddScoped<ICourseTermTimeTableCreateService, CourseTermTimeTableCreateService>();
            _ = service.AddScoped<ICourseTermTimeTableDeleteService, CourseTermTimeTableDeleteService>();
            _ = service.AddScoped<ICourseTermTimeTableListConvertor, CourseTermTimeTableListConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableListService, CourseTermTimeTableListService>();
            _ = service.AddScoped<ILectorListService, LectorListService>();
            _ = service.AddScoped<ILectorListConvertor, LectorListConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableUpdateConvertor, CourseTermTimeTableUpdateConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableUpdatevalidator, CourseTermTimeTableUpdatevalidator>();
            _ = service.AddScoped<ICourseTermDateRepository, CourseTermDateRepository>();
        }


        public static void RegistrationOrganizationStudyHour(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationStudyHourRepository, OrganizationStudyHourRepository>();
            _ = service.AddScoped<IOrganizationStudyHourCreateService, OrganizationStudyHourCreateService>();
            _ = service.AddScoped<IOrganizationStudyHourCreateConvertor, OrganizationStudyHourCreateConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourCreateValidator, OrganizationStudyHourCreateValidator>();
            _ = service.AddScoped<IOrganizationStudyHourDeleteService, OrganizationStudyHourDeleteService>();
            _ = service.AddScoped<IOrganizationStudyHourListService, OrganizationStudyHourListService>();
            _ = service.AddScoped<IOrganizationStudyHourListConvertor, OrganizationStudyHourListConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourRestoreService, OrganizationStudyHourRestoreService>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateService, OrganizationStudyHourUpdateService>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateConvertor, OrganizationStudyHourUpdateConvertor>();
            _ = service.AddScoped<IOrganizationStudyHourUpdateValidator, OrganizationStudyHourUpdateValidator>();
            _ = service.AddScoped<IOrganizationRoleListConvertor, OrganizationRoleListConvertor>();
            _ = service.AddScoped<IOrganizationRoleListService, OrganizationRoleListService>();
            _ = service.AddScoped<IUserInOrganizationCreateService, UserInOrganizationCreateService>();
            _ = service.AddScoped<IUserInOrganizationCreateValidator, UserInOrganizationCreateValidator>();
            _ = service.AddScoped<IUserInOrganizationDeleteService, UserInOrganizationDeleteService>();
            _ = service.AddScoped<IUserInOrganizationDetailService, UserInOrganizationDetailService>();
            _ = service.AddScoped<IUserInOrganizationListConvertor, UserInOrganizationListConvertor>();
            _ = service.AddScoped<IUserInOrganizationListService, UserInOrganizationListService>();
            _ = service.AddScoped<IUserInOrganizationRestoreService, UserInOrganizationRestoreService>();
            _ = service.AddScoped<IUserInOrganizationUpdateService, UserInOrganizationUpdateService>();
            _ = service.AddScoped<IUserInOrganizationUpdateValidator, UserInOrganizationUpdateValidator>();
        }


        public static void RegistrationCodeBook(this IServiceCollection service)
        {
            _ = service.AddScoped(typeof(ICodeBookRepository<>), typeof(CodeBookRepository<>));

        }


        public static void RegisterEmail(this IServiceCollection service)
        {
            _ = service.AddScoped<ISendEmailRepository, SendEmailRepository>();
            _ = service.AddScoped<IPowerPointIntegration, PowerPointIntegration>();
        }

        public static void RegisterIntegration(this IServiceCollection service)
        {
            _ = service.AddScoped<IMailKitIntegration, MailKitIntegration>();
            _ = service.AddScoped<IHttpClient, HttpClient>();
        }

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

            _ = service.AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();
        }

        public static void RegistrationOrganizationSetting(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationSettingRepository, OrganizationSettingRepository>();
            _ = service.AddScoped<IGetOrganizationSettingService, GetOrganizationSettingService>();
            _ = service.AddScoped<IGetOrganizationSettingConvertor, GetOrganizationSettingConvertor>();
            _ = service.AddScoped<IOrganizationSettingUpdateService, OrganizationSettingUpdateService>();
            _ = service.AddScoped<IOrganizationSettingUpdateConvertor, OrganizationSettingUpdateConvertor>();
            _ = service.AddScoped<IOrganizationSettingUpdateValidator, OrganizationSettingUpdateValidator>();
        }


        public static void RegistrationOrganization(this IServiceCollection service)
        {
            _ = service.AddScoped<IOrganizationRepository, OrganizationRepository>();
        }


        public static void RegistrationIUserInOrganization(this IServiceCollection service)
        {
            _ = service.AddScoped<IUserInOrganizationRepository, UserInOrganizationRepository>();
        }

        public static void RegisterLicense(this IServiceCollection service)
        {
            _ = service.AddScoped<ILicenseChangeRepository, LicenseChangeRepository>();
        }


        public static void RegisterBranch(this IServiceCollection service)
        {
            _ = service.AddScoped<IBranchRepository, BranchRepository>();
            _ = service.AddScoped<IBranchCreateService, BranchCreateService>();
            _ = service.AddScoped<IBranchCreateValidator, BranchCreateValidator>();
            _ = service.AddScoped<IBranchCreateConvertor, BranchCreateConvertor>();
            _ = service.AddScoped<IBranchDeleteService, BranchDeleteService>();
            _ = service.AddScoped<IBranchDetailService, BranchDetailService>();
            _ = service.AddScoped<IBranchListService, BranchListService>();
            _ = service.AddScoped<IBranchListConvertor, BranchListConvertor>();
            _ = service.AddScoped<IBranchRestoreService, BranchRestoreService>();
            _ = service.AddScoped<IBranchUpdateService, BranchUpdateService>();
            _ = service.AddScoped<IBranchUpdateValidator, BranchUpdateValidator>();
            _ = service.AddScoped<IBranchUpdateConvertor, BranchUpdateConvertor>();
            _ = service.AddScoped<IChangeMainBranchService, ChangeMainBranchService>();
            _ = service.AddScoped<IBranchDetailConvertor, BranchDetailConvertor>();
        }


        public static void RegistrationCourse(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseRepository, CourseRepository>();

            _ = service.AddScoped<ICourseDetailService, CourseDetailService>();
            _ = service.AddScoped<ICourseDetailConvertor, CourseDetailConvertor>();
            _ = service.AddScoped<ICourseCreateConvertor, CourseCreateConvertor>();
            _ = service.AddScoped<ICourseCreateService, CourseCreateService>();
            _ = service.AddScoped<ICourseCreateValidator, CourseCreateValidator>();
            _ = service.AddScoped<ICourseDeleteService, CourseDeleteService>();
            _ = service.AddScoped<ICourseListConvertor, CourseListConvertor>();
            _ = service.AddScoped<ICourseListService, CourseListService>();
            _ = service.AddScoped<ICourseRestoreService, CourseRestoreService>();
            _ = service.AddScoped<ICourseUpdateConvertor, CourseUpdateConvertor>();
            _ = service.AddScoped<ICourseUpdateValidator, CourseUpdateValidator>();
            _ = service.AddScoped<ICourseUpdateService, CourseUpdateService>();
        }


        public static void RegistrationClassRoom(this IServiceCollection service)
        {
            _ = service.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            _ = service.AddScoped<IClassRoomCreateService, ClassRoomCreateService>();
            _ = service.AddScoped<IClassRoomCreateValidator, ClassRoomCreateValidator>();
            _ = service.AddScoped<IClassRoomCreateConvertor, ClassRoomCreateConvertor>();
            _ = service.AddScoped<IClassRoomUpdateService, ClassRoomUpdateService>();
            _ = service.AddScoped<IClassRoomUpdateValidator, ClassRoomUpdateValidator>();
            _ = service.AddScoped<IClassRoomUpdateConvertor, ClassRoomUpdateConvertor>();
            _ = service.AddScoped<IClassRoomDeleteService, ClassRoomDeleteService>();
            _ = service.AddScoped<IClassRoomDetailService, ClassRoomDetailService>();
            _ = service.AddScoped<IClassRoomDetailConvertor, ClassRoomDetailConvertor>();
            _ = service.AddScoped<IClassRoomListService, ClassRoomListService>();
            _ = service.AddScoped<IClassRoomListConvertor, ClassRoomListConvertor>();
            _ = service.AddScoped<IClassRoomRestoreService, ClassRoomRestoreService>();
            _ = service.AddScoped<IClassRoomTimeTableService, ClassRoomTimeTableService>();
        }


        public static void RegistrationCourseTerm(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermStudentCreateService, CourseTermStudentCreateService>();
            _ = service.AddScoped<ICourseTermStudentCreateValidator, CourseTermStudentCreateValidator>();
            _ = service.AddScoped<ICourseTermStudentDeleteService, CourseTermStudentDeleteService>();
            _ = service.AddScoped<ICourseTermStudentListConvertor, CourseTermStudentListConvertor>();
            _ = service.AddScoped<ICourseTermStudentListService, CourseTermStudentListService>();
            _ = service.AddScoped<ICourseTermStudentCreateConvertor, CourseTermStudentCreateConvertor>();
            _ = service.AddScoped<ICourseTermRepository, CourseTermRepository>();
        }

        public static void RegistrationCourseLector(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLectorRepository, CourseLectorRepository>();
        }


        public static void RegistrionCourseStudent(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            _ = service.AddScoped<IStudentInGroupCourseTermCreateService, StudentInGroupCourseTermCreateService>();
            _ = service.AddScoped<IStudentInGroupCourseTermCreateConvertor, StudentInGroupCourseTermCreateConvertor>();
            _ = service.AddScoped<IStudentInGroupCourseTermCreateValidator, StudentInGroupCourseTermCreateValidator>();
            _ = service.AddScoped<IOrganizationStudyHourDetailService, OrganizationStudyHourDetailService>();
            _ = service.AddScoped<IOrganizationStudyHourDetailConvertor, OrganizationStudyHourDetailConvertor>();
            _ = service.AddScoped<ICourseTermCreateService, CourseTermCreateService>();
            _ = service.AddScoped<ICourseTermCreateConvertor, CourseTermCreateConvertor>();
            _ = service.AddScoped<ICourseTermCreateValidator, CourseTermCreateValidator>();
            _ = service.AddScoped<ICourseTermDeleteService, CourseTermDeleteService>();
            _ = service.AddScoped<ICourseTermDetailConvertor, CourseTermDetailConvertor>();
            _ = service.AddScoped<ICourseTermDetailService, CourseTermDetailService>();
            _ = service.AddScoped<ICourseTermListConvertor, CourseTermListConvertor>();
            _ = service.AddScoped<ICourseTermListService, CourseTermListService>();
            _ = service.AddScoped<ICourseTermRestoreService, CourseTermRestoreService>();
            _ = service.AddScoped<ICourseTermUpdateConvertor, CourseTermUpdateConvertor>();
            _ = service.AddScoped<ICourseTermUpdateService, CourseTermUpdateService>();
            _ = service.AddScoped<ICourseTermUpdateValidator, CourseTermUpdateValidator>();
            _ = service.AddScoped<ILectorMultipleDeleteService, LectorMultipleDeleteService>();
            _ = service.AddScoped<IStudentInGroupCourseTermMultipleDeleteService, StudentInGroupCourseTermMultipleDeleteService>();
        }

        public static void RegistrationCourseLesson(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
            _ = service.AddScoped<ICourseLessonCreateConvertor, CourseLessonCreateConvertor>();
            _ = service.AddScoped<ICourseLessonCreateService, CourseLessonCreateService>();
            _ = service.AddScoped<ICourseLessonCreateValidator, CourseLessonCreateValidator>();
            _ = service.AddScoped<ICourseLessonDeleteService, CourseLessonDeleteService>();
            _ = service.AddScoped<ICourseLessonDetailConvertor, CourseLessonDetailConvertor>();
            _ = service.AddScoped<ICourseLessonDetailService, CourseLessonDetailService>();
            _ = service.AddScoped<ICourseLessonListConvertor, CourseLessonListConvertor>();
            _ = service.AddScoped<ICourseLessonListService, CourseLessonListService>();
            _ = service.AddScoped<ICourseLessonRestoreService, CourseLessonRestoreService>();
            _ = service.AddScoped<ICourseLessonUpdateConvertor, CourseLessonUpdateConvertor>();
            _ = service.AddScoped<ICourseLessonUpdateService, CourseLessonUpdateService>();
            _ = service.AddScoped<ICourseLessonUpdateValidator, CourseLessonUpdateValidator>();
            _ = service.AddScoped<ICourseLessonUpdatePositionService, CourseLessonUpdatePositionService>();
            _ = service.AddScoped<ICourseLessonFileUploadService, CourseLessonFileUploadService>();
        }

        public static void RegistrationCourseLessonItem(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseLessonItemRepository, CourseLessonItemRepository>();
            _ = service.AddScoped<ICourseLessonItemCreateConvertor, CourseLessonItemCreateConvertor>();
            _ = service.AddScoped<ICourseLessonItemCreateService, CourseLessonItemCreateService>();
            _ = service.AddScoped<ICourseLessonItemCreateValidator, CourseLessonItemCreateValidator>();
            _ = service.AddScoped<ICourseLessonItemDeleteService, CourseLessonItemDeleteService>();
            _ = service.AddScoped<ICourseLessonItemDetailConvertor, CourseLessonItemDetailConvertor>();
            _ = service.AddScoped<ICourseLessonItemDetailService, CourseLessonItemDetailService>();
            _ = service.AddScoped<ICourseLessonItemListConvertor, CourseLessonItemListConvertor>();
            _ = service.AddScoped<ICourseLessonItemListService, CourseLessonItemListService>();
            _ = service.AddScoped<ICourseLessonItemRestoreService, CourseLessonItemRestore>();
            _ = service.AddScoped<ICourseLessonItemUpdateConvertor, CourseLessonItemUpdateConvertor>();
            _ = service.AddScoped<ICourseLessonItemUpdateService, CourseLessonItemUpdateService>();
            _ = service.AddScoped<ICourseLessonItemUpdateValidator, CourseLessonItemUpdateValidator>();
            _ = service.AddScoped<ICourseLessonItemUpdatePositionService, CourseLessonItemUpdatePositionService>();
            _ = service.AddScoped<ICourseLessonItemFileUploadService, CourseLessonItemFileUploadService>();
            _ = service.AddScoped<ICourseLessonItemFileDeleteService, CourseLessonItemFileDeleteService>();
        }

        public static void RegistratioBankOfQuestion(this IServiceCollection service)
        {
            _ = service.AddScoped<IBankOfQuestionCreateConvertor, BankOfQuestionCreateConvertor>();
            _ = service.AddScoped<IBankOfQuestionCreateService, BankOfQuestionCreateService>();
            _ = service.AddScoped<IBankOfQuestionCreateValidator, BankOfQuestionCreateValidator>();
            _ = service.AddScoped<IBankOfQuestionDeleteService, BankOfQuestionDeleteService>();
            _ = service.AddScoped<IBankOfQuestionDetailConvertor, BankOfQuestionDetailConvertor>();
            _ = service.AddScoped<IBankOfQuestionDetailService, BankOfQuestionDetailService>();
            _ = service.AddScoped<IBankOfQuestionListConvertor, BankOfQuestionListConvertor>();
            _ = service.AddScoped<IBankOfQuestionListService, BankOfQuestionListService>();
            _ = service.AddScoped<IBankOfQuestionRestoreService, BankOfQuestionRestoreService>();
            _ = service.AddScoped<IBankOfQuestionUpdateConvertor, BankOfQuestionUpdateConvertor>();
            _ = service.AddScoped<IBankOfQuestionUpdateService, BankOfQuestionUpdateService>();
            _ = service.AddScoped<IBankOfQuestionUpdateValidator, BankOfQuestionUpdateValidator>();
            _ = service.AddScoped<IBankOfQuestionRepository, BankOfQuestionRepository>();
        }

        public static void RegistrationQuestion(this IServiceCollection service)
        {
            _ = service.AddScoped<IQuestionRepository, QuestionRepository>();

            _ = service.AddScoped<IQuestionCreateConvertor, QuestionCreateConvertor>();
            _ = service.AddScoped<IQuestionCreateService, QuestionCreateService>();
            _ = service.AddScoped<IQuestionCreateValidator, QuestionCreateValidator>();
            _ = service.AddScoped<IQuestionDeleteService, QuestionDeleteService>();
            _ = service.AddScoped<IQuestionDetailConvertor, QuestionDetailConvertor>();
            _ = service.AddScoped<IQuestionDetailService, QuestionDetailService>();
            _ = service.AddScoped<IQuestionFileUploadFileUploadService, QuestionFileUploadFileUploadService>();
            _ = service.AddScoped<IQuestionListConvertor, QuestionListConvertor>();
            _ = service.AddScoped<IQuestionListService, QuestionListService>();
            _ = service.AddScoped<IQuestionRestoreService, QuestionRestoreService>();
            _ = service.AddScoped<IQuestionUpdateConvertor, QuestionUpdateConvertor>();
            _ = service.AddScoped<IQuestionUpdateService, QuestionUpdateService>();
            _ = service.AddScoped<IQuestionUpdateValidator, QuestionUpdateValidator>();
        }

        public static void RegistrationAnswer(this IServiceCollection service)
        {
            _ = service.AddScoped<IAnswerRepository, AnswerRepository>();
            _ = service.AddScoped<IAnswerCreateConvertor, AnswerCreateConvertor>();
            _ = service.AddScoped<IAnswerCreateCommand, AnswerCreateCommand>();
            _ = service.AddScoped<IAnswerCreateValidator, AnswerCreateValidator>();
            _ = service.AddScoped<IAnswerDeleteCommand, AnswerDeleteCommand>();
            _ = service.AddScoped<IAnswerDetailConvertor, AnswerDetailConvertor>();
            _ = service.AddScoped<IAnswerDetailCommand, AnswerDetailCommand>();
            _ = service.AddScoped<IAnswerFileUploadCommand, AnswerFileUploadCommand>();
            _ = service.AddScoped<IAnswerListConvertor, AnswerListConvertor>();
            _ = service.AddScoped<IAnswerListCommand, AnswerListCommand>();
            _ = service.AddScoped<IAnswerRestoreCommand, AnswerRestoreCommand>();
            _ = service.AddScoped<IAnswerUpdateConvertor, AnswerUpdateConvertor>();
            _ = service.AddScoped<IAnswerUpdateService, AnswerUpdateCommand>();
            _ = service.AddScoped<IAnswerUpdateValidator, AnswerUpdateValidator>();
            _ = service.AddScoped<IDeleteAnswerInQuestionCommnad, DeleteAnswerInQuestionCommand>();
        }

        public static void RegisterNotification(this IServiceCollection service)
        {
            _ = service.AddScoped<INotificationRepository, NotificationRepository>();
        }

        public static void RegisterFileUpload(this IServiceCollection service)
        {
            _ = service.AddScoped(typeof(IFileUploadRepository<>), typeof(FileUploadRepository<>));
        }


        public static void RegisterTest(this IServiceCollection service)
        {
            _ = service.AddScoped<ITestRepository, TestRepository>();
            _ = service.AddScoped<ICourseTestBankOfQuestionRepository, CourseTestBankOfQuestionRepository>();
            _ = service.AddScoped<ICourseTestCreateConvertor, CourseTestCreateConvertor>();
            _ = service.AddScoped<ICourseTestCreateService, CourseTestCreateService>();
            _ = service.AddScoped<ICourseTestCreateValidator, CourseTestCreateValidator>();
            _ = service.AddScoped<ICourseTestUpdateConvertor, CourseTestUpdateConvertor>();
            _ = service.AddScoped<ICourseTestUpdateService, CourseTestUpdateService>();
            _ = service.AddScoped<ICourseTestUpdateValidator, CourseTestUpdateValidator>();
        }

        public static void RegisterPage(this IServiceCollection service) { }

        public static void RegisterLifeTime(this IServiceCollection service)
        {
            _ = service.AddScoped<ILinkLifeTimeRepository, LinkLifeTimeRepository>();
        }

        public static void RegisterCertificate(this IServiceCollection service)
        {
            _ = service.AddScoped<ICertificateRepository, CertificateRepository>();
            _ = service.AddScoped<IUserCertificateRepository, UserCertificateRepository>();
            _ = service.AddScoped<ICertificateCreateService, CertificateCreateService>();
            _ = service.AddScoped<ICertificateCreateConvertor, CertificateCreateConvertor>();
            _ = service.AddScoped<ICertificateCreateValidator, CertificateCreateValidator>();
            _ = service.AddScoped<ICertificateDetailService, CertificateDetailService>();
            _ = service.AddScoped<ICertificateDetailConvertor, CertificateDetailConvertor>();
            _ = service.AddScoped<ICertificateListConvertor, CertificateListConvertor>();
            _ = service.AddScoped<ICertificateListService, CertificateListService>();
            _ = service.AddScoped<ICertificateUpdateConvertor, CertificateUpdateConvertor>();
            _ = service.AddScoped<ICertificateUpdateService, CertificateUpdateService>();
            _ = service.AddScoped<ICertificateUpdateValidator, CertificateUpdateValidator>();
            _ = service.AddScoped<ICertificateDeleteService, CertificateDeleteService>();
            _ = service.AddScoped<ICertificateRestoreService, CertificateRestoreService>();
        }

        public static void RegisterPdf(this IServiceCollection service)
        {
            _ = service.AddScoped<IPdfSharpIntegration, PdfSharpIntegration>();
        }

        public static void RegisterSendMessage(this IServiceCollection service)
        {
            _ = service.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();
            _ = service.AddScoped<IMessageTemplateCreateConvertor, MessageTemplateCreateConvertor>();
            _ = service.AddScoped<IMessageTemplateCreateService, MessageTemplateCreateService>();
            _ = service.AddScoped<IMessageTemplateCreateValidator, MessageTemplateCreateValidator>();
            _ = service.AddScoped<IMessageTemplateDeleteService, MessageTemplateDeleteService>();
            _ = service.AddScoped<IMessageTemplateDetailConvertor, MessageTemplateDetailConvertor>();
            _ = service.AddScoped<IMessageTemplateDetailService, MessageTemplateDetailService>();
            _ = service.AddScoped<IMessageTemplateListConvertor, MessageTemplateListConvertor>();
            _ = service.AddScoped<IMessageTemplateListService, MessageTemplateListService>();
            _ = service.AddScoped<IMessageTemplateRestoreService, MessageTemplateRestoreService>();
            _ = service.AddScoped<IMessageTemplateUpdateConvertor, MessageTemplateUpdateConvertor>();
            _ = service.AddScoped<IMessageTemplateUpdateService, MessageTemplateUpdateService>();
            _ = service.AddScoped<IMessageTemplateUpdateValidator, MessageTemplateUpdateValidator>();
            _ = service.AddScoped<IMessageTemplateDropDownService, MessageTemplateDropDownService>();
            _ = service.AddScoped<IMessageTemplateDropDownConvertor, MessageTemplateDropDownConvertor>();
            _ = service.AddScoped<IClassRoomDropDownConvertor, ClassRoomDropDownConvertor>();
            _ = service.AddScoped<IClassRoomDropDownService, ClassRoomDropDownService>();
            _ = service.AddScoped<IOrganizationStudyHourDropDownService, OrganizationStudyHourDropDownService>();
            _ = service.AddScoped<IOrganizationStudyHourDropDownConvertor, OrganizationStudyHourDropDownConvertor>();
            _ = service.AddScoped<IStudentGroupDropDownService, StudentGroupDropDownService>();
            _ = service.AddScoped<IStudentGroupDropDownConvertor, StudentGroupDropDownConvertor>();
            _ = service.AddScoped<IUserInOrganizationDropDownService, UserInOrganizationDropDownService>();
            _ = service.AddScoped<IUserInOrganizationDropDownConvertor, UserInOrganizationDropDownConvertor>();
            _ = service.AddScoped<IBankOfQuestionDropDownService, BankOfQuestionDropDownService>();
            _ = service.AddScoped<IBankOfQuestionDropDownConvertor, BankOfQuestionDropDownConvertor>();
            _ = service.AddScoped<INotificationCreateConvertor, NotificationCreateConvertor>();
            _ = service.AddScoped<INotificationCreateService, NotificationCreateService>();
            _ = service.AddScoped<INotificationCreateValidator, NotificationCreateValidator>();
        }

        public static void RegisterStudentGroup(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
            _ = service.AddScoped<IStudentGroupCreateConvertor, StudentGroupCreateConvertor>();
            _ = service.AddScoped<IStudentGroupCreateService, StudentGroupCreateService>();
            _ = service.AddScoped<IStudentGroupCreateValidator, StudentGroupCreateValidator>();
            _ = service.AddScoped<IStudentGroupDeleteService, StudentGroupDeleteService>();
            _ = service.AddScoped<IStudentGroupDetailConvertor, StudentGroupDetailConvertor>();
            _ = service.AddScoped<IStudentGroupDetailService, StudentGroupDetailService>();
            _ = service.AddScoped<IStudentGroupListConvertor, StudentGroupListConvertor>();
            _ = service.AddScoped<IStudentGroupListService, StudentGroupListService>();
            _ = service.AddScoped<IStudentGroupRestoreService, StudentGroupRestoreService>();
            _ = service.AddScoped<IStudentGroupUpdateConvertor, StudentGroupUpdateConvertor>();
            _ = service.AddScoped<IStudentGroupUpdateService, StudentGroupUpdateService>();
            _ = service.AddScoped<IStudentGroupUpdateValidator, StudentGroupUpdateValidator>();
            _ = service.AddScoped<IOrganizationRoleDetailService, OrganizationRoleDetailService>();
            _ = service.AddScoped<IOrganizationRoleDetailConvertor, OrganizationRoleDetailConvertor>();
        }

        public static void RegisterCourseMaterial(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseMaterialRepository, CourseMaterialRepository>();
            _ = service.AddScoped<ICourseMaterialCreateConvertor, CourseMaterialCreateConvertor>();
            _ = service.AddScoped<ICourseMaterialCreateService, CourseMaterialCreateService>();
            _ = service.AddScoped<ICourseMaterialCreateValidator, CourseMaterialCreateValidator>();
            _ = service.AddScoped<ICourseMaterialDeleteService, CourseMaterialDeleteService>();
            _ = service.AddScoped<ICourseMaterialDetailConvertor, CourseMaterialDetailConvertor>();
            _ = service.AddScoped<ICourseMaterialDetailService, CourseMaterialDetailService>();
            _ = service.AddScoped<ICourseMaterialListConvertor, CourseMaterialListConvertor>();
            _ = service.AddScoped<ICourseMaterialListService, CourseMaterialListService>();
            _ = service.AddScoped<ICourseMaterialRestoreService, CourseMaterialRestoreService>();
            _ = service.AddScoped<ICourseMaterialUpdateConvertor, CourseMaterialUpdateConvertor>();
            _ = service.AddScoped<ICourseMaterialUpdateService, CourseMaterialUpdateService>();
            _ = service.AddScoped<ICourseMaterialUpdateValidator, CourseMaterialUpdateValidator>();
            _ = service.AddScoped<IGetFilesConvertor, GetFilesConvertor>();
            _ = service.AddScoped<IGetFilesService, GetFilesService>();
            _ = service.AddScoped<ICourseMaterialFileUploadService, CourseMaterialFileUploadService>();
            _ = service.AddScoped<ICourseMaterialFileDeleteService, CourseMaterialFileDeleteService>();
        }


        public static void RegisterNote(this IServiceCollection service)
        {
            _ = service.AddScoped<INoteRepository, NoteRepository>();
            _ = service.AddScoped<INoteCreateCommand, NoteCreateCommand>();
            _ = service.AddScoped<INoteCreateConvertor, NoteCreateConvertor>();
            _ = service.AddScoped<INoteCreateValidator, NoteCreateValidator>();
            _ = service.AddScoped<INoteDeleteCommand, NoteDeleteCommand>();
            _ = service.AddScoped<INoteDetailConvertor, NoteDetailConvertor>();
            _ = service.AddScoped<INoteDetailCommand, NoteDetailCommand>();
            _ = service.AddScoped<INoteImageCreateCommand, NoteImageCreateCommand>();
            _ = service.AddScoped<INoteImageCreateConvertor, NoteImageCreateConvertor>();
            _ = service.AddScoped<INoteImageCreateValidator, NoteImageCreateValidator>();
            _ = service.AddScoped<INoteImageUpdateCommand, NoteImageUpdateCommand>();
            _ = service.AddScoped<INoteImageUpdateConvertor, NoteImageUpdateConvertor>();
            _ = service.AddScoped<INoteImageUpdateValidator, NoteImageUpdateValidator>();
            _ = service.AddScoped<INoteListConvertor, NoteListConvertor>();
            _ = service.AddScoped<INoteListCommand, NoteListCommand>();
            _ = service.AddScoped<INoteRestoreCommand, NoteRestoreCommand>();
            _ = service.AddScoped<INoteUpdateCommand, NoteUpdateCommand>();
            _ = service.AddScoped<INoteUpdateConvertor, NoteUpdateConvertor>();
            _ = service.AddScoped<INoteUpdateValidator, NoteUpdateValidator>();
        }

        public static void RegisterCourseTable(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTableRepository, CourseTableRepository>();
        }


        public static void RegisterChat(this IServiceCollection service)
        {
            _ = service.AddScoped<IChatRepository, ChatRepository>();
            _ = service.AddScoped<IChatCreateCommand, ChatCreateCommand>();
            _ = service.AddScoped<IChatCreateConvertor, ChatCreateConvertor>();
            _ = service.AddScoped<IChatCreateValidator, ChatCreateValidator>();
            _ = service.AddScoped<IChatDeleteCommand, ChatDeleteCommand>();
            _ = service.AddScoped<IChatListCommand, ChatListCommand>();
            _ = service.AddScoped<IChatListConvertor, ChatListConvertor>();
            _ = service.AddScoped<IChatUpdateCommand, ChatUpdateCommand>();
            _ = service.AddScoped<IChatUpdateConvertor, ChatUpdateConvertor>();
            _ = service.AddScoped<IChatUpdateValidator, ChatUpdateValidator>();
            _ = service.AddScoped<IImagePng, ImagePng>();
        }


        public static void RegistrationAttendanceStudent(this IServiceCollection service)
        {
            _ = service.AddScoped<IAttendanceStudentRepository, AttendanceStudentRepository>();
            _ = service.AddScoped<IStudentAttendanceCreateCommand, StudentAttendanceCreateCommand>();
            _ = service.AddScoped<IStudentAttendanceCreateConvertor, StudentAttendanceCreateConvertor>();
            _ = service.AddScoped<IStudentAttendanceCreateValidator, StudentAttendanceCreateValidator>();
            _ = service.AddScoped<IStudentAttendanceDeleteCommand, StudentAttendanceDeleteCommand>();
            _ = service.AddScoped<IStudentAttendanceListCommand, StudentAttendanceListCommand>();
            _ = service.AddScoped<IStudentAttendanceListConvertor, StudentAttendanceListConvertor>();
            _ = service.AddScoped<IStudentAttendanceRestoreCommand, StudentAttendanceRestoreCommand>();
        }

        public static void RegistrationCouseStudentMaterial(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseStudentMaterialRepository, CouseStudentMaterialRepository>();
            _ = service.AddScoped<IStudentEvaluationRestoreService, StudentEvaluationRestoreService>();
            _ = service.AddScoped<IStudentEvaluationUpdateConvertor, StudentEvaluationUpdateConvertor>();
            _ = service.AddScoped<IStudentEvaluationUpdateService, StudentEvaluationUpdateService>();
            _ = service.AddScoped<IStudentEvaluationUpdateValidator, StudentEvaluationUpdateValidator>();
        }

        public static void RegistrationStudentEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentEvaluationRepository, StudentEvaluationRepository>();
            _ = service.AddScoped<IStudentEvaluationCreateConvertor, StudentEvaluationCreateConvertor>();
            _ = service.AddScoped<IStudentEvaluationCreateService, StudentEvaluationCreateService>();
            _ = service.AddScoped<IStudentEvaluationCreateValidator, StudentEvaluationCreateValidator>();
            _ = service.AddScoped<IStudentEvaluationDeleteService, StudentEvaluationDeleteService>();
            _ = service.AddScoped<IStudentEvaluationListConvertor, StudentEvaluationListConvertor>();
            _ = service.AddScoped<IStudentEvaluationListService, StudentEvaluationListService>();
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
            _ = service.AddScoped<IMyTimeTableCommand, MyTimeTableCommand>();
        }


        public static void RegistrationRoute(this IServiceCollection service)
        {
            _ = service.AddScoped<IRouteRepository, RouteRepository>();
            _ = service.AddScoped<IRouteCreateConvertor, RouteCreateConvertor>();
            _ = service.AddScoped<IRouteCreateService, RouteCreateService>();
            _ = service.AddScoped<IRouteCreateValidator, RouteCreateValidator>();
            _ = service.AddScoped<IRouteDeleteService, RouteDeleteService>();
            _ = service.AddScoped<IRouteDetailConvertor, RouteDetailConvertor>();
            _ = service.AddScoped<IRouteDetailService, RouteDetailService>();
            _ = service.AddScoped<IRouteListConvertor, RouteListConvertor>();
            _ = service.AddScoped<IRouteListService, RouteListService>();
            _ = service.AddScoped<IRouteRestoreService, RouteRestoreService>();
            _ = service.AddScoped<IRouteUpdateConvertor, RouteUpdateConvertor>();
            _ = service.AddScoped<IRouteUpdateService, RouteUpdateService>();
            _ = service.AddScoped<IRouteUpdateValidator, RouteUpdateValidator>();
            _ = service.AddScoped<IGeneratePasswordService, GeneratePasswordService>();
        }

        public static void RegistrationPermissions(this IServiceCollection service)
        {
            _ = service.AddScoped<IPermissionsRepository, PermissionsRepository>();
            _ = service.AddScoped<IPermissionsCreateService, PermissionsCreateService>();
            _ = service.AddScoped<IPermissionsListService, PermissionsListService>();
            _ = service.AddScoped<IPermissionsDetailService, PermissionsDetailService>();
            _ = service.AddScoped<IPermissionsUpdateService, PermissionsUpdateService>();
            _ = service.AddScoped<IPermissionsDeleteService, PermissionsDeleteService>();
            _ = service.AddScoped<IPermissionsRestoreService, PermissionsRestoreService>();
            _ = service.AddScoped<IPermissionsCreateValidator, PermissionsCreateValidator>();
            _ = service.AddScoped<IPermissionsUpdateValidator, PermissionsUpdateValidator>();
            _ = service.AddScoped<IPermissionsCreateConvertor, PermissionsCreateConvertor>();
            _ = service.AddScoped<IPermissionsUpdateConvertor, PermissionsUpdateConvertor>();
            _ = service.AddScoped<IPermissionsListConvertor, PermissionsListConvertor>();
            _ = service.AddScoped<IPermissionsDetailConvertor, PermissionsDetailConvertor>();
            _ = service.AddScoped<IRegisterUserService, RegisterUserService>();
            _ = service.AddScoped<IRegisterUserValidator, RegisterUserValidator>();
            _ = service.AddScoped<IRegisterUserConvertor, RegisterUserConvertor>();
            _ = service.AddScoped<ISetNewPasswordService, SetNewPasswordService>();
            _ = service.AddScoped<ISetNewPasswordValidator, SetNewPasswordValidator>();
            _ = service.AddScoped<IActivateUserService, ActivateUserService>();
            _ = service.AddScoped<IActivateUserValidator, ActivateUserValidator>();
            _ = service.AddScoped<IGetUserTokenBysocialNetworkService, GetUserTokenBySocialNetworkService>();
            _ = service.AddScoped<IGetUserTokenConvertor, GetUserTokenConvertor>();
            _ = service.AddScoped<IGetUserTokenService, GetUserTokenService>();
            _ = service.AddScoped<IGetUserTokenAdminService, GetUserTokenAdminService>();
            _ = service.AddScoped<ILicenceListService, LicenceListService>();
            _ = service.AddScoped<ILicenceListConvertor, LicenceListConvertor>();
            _ = service.AddScoped<IOrganizationList, OrganizationList>();
            _ = service.AddScoped<IOrganizationListConvertor, OrganizationListConvertor>();
            _ = service.AddScoped<IOrganizationWebDetail, OrganizationWebDetail>();
            _ = service.AddScoped<IOrganizationWebDetailConvertor, OrganizationWebDetailConvertor>();
            _ = service.AddScoped<IGetOrganizationSettingByUrlService, GetOrganizationSettingByUrlService>();
            _ = service.AddScoped<IGetOrganizationSettingByUrlConvertor, GetOrganizationSettingByUrlConvertor>();
            _ = service.AddScoped<IUserDetailService, UserDetailService>();
            _ = service.AddScoped<IUserDetailConvertor, UserDetailConvertor>();
            _ = service.AddScoped<IRefreshTokenService, RefreshTokenService>();
            _ = service.AddScoped<IUserUpdateService, UserUpdateService>();
            _ = service.AddScoped<IUserUpdateConvertor, UserUpdateConvertor>();
            _ = service.AddScoped<IUserUpdateValidator, UserUpdateValidator>();
            _ = service.AddScoped<IUserDeleteService, UserDeleteService>();
            _ = service.AddScoped<IChangePasswordService, ChangePasswordService>();
            _ = service.AddScoped<IChangePasswordValidator, ChangePasswordValidator>();
            _ = service.AddScoped<IChangePasswordConvertor, ChangePasswordConvertor>();
            _ = service.AddScoped<ISetPasswordService, SetPasswordService>();
            _ = service.AddScoped<ISetPasswordValidator, SetPasswordValidator>();
            _ = service.AddScoped<ISetPasswordConvertor, SetPasswordConvertor>();
            _ = service.AddScoped<IMyOrganizationConvertor, MyOrganizationConvertor>();
            _ = service.AddScoped<IMyOrganizationService, MyOrganizationService>();
            _ = service.AddScoped<IMyCertificateService, MyCertificateService>();
            _ = service.AddScoped<IMyCertificateConvertor, MyCertificateConvertor>();
            _ = service.AddScoped<IMyEvaluationService, MyEvaluationService>();
            _ = service.AddScoped<IMyEvaluationConvertor, MyEvaluationConvertor>();
            _ = service.AddScoped<IManagedCourseService, ManagedCourseService>();
            _ = service.AddScoped<IManagedCourseConvertor, ManagedCourseConvertor>();
            _ = service.AddScoped<IMyAttendanceService, MyAttendanceService>();
            _ = service.AddScoped<IMyAttendanceConvertor, MyAttendanceConvertor>();
            _ = service.AddScoped<INotificationListService, NotificationListService>();
            _ = service.AddScoped<INotificationListConvertor, NotificationListConvertor>();
            _ = service.AddScoped<INotificationUpdateService, NotificationUpdateService>();
            _ = service.AddScoped<INotificationUpdateConvertor, NotificationUpdateConvertor>();
            _ = service.AddScoped<INotificationUpdateValidator, NotificationUpdateValidator>();
            _ = service.AddScoped<IOrganizationCreateService, OrganizationCreateService>();
            _ = service.AddScoped<IOrganizationCreateConvertor, OrganizationCreateConvertor>();
            _ = service.AddScoped<IOrganizationCreateValidator, OrganizationCreateValidator>();
            _ = service.AddScoped<IOrganizationDetailService, OrganizationDetailService>();
            _ = service.AddScoped<IOrganizationDetailConvertor, OrganizationDetailConvertor>();
            _ = service.AddScoped<IOrganizationUpdateService, OrganizationUpdateService>();
            _ = service.AddScoped<IOrganizationUpdateConvertor, OrganizationUpdateConvertor>();
            _ = service.AddScoped<IOrganizationUpdateValidator, OrganizationUpdateValidator>();
            _ = service.AddScoped<IOrganizaionDeleteService, OrganizaionDeleteService>();
            _ = service.AddScoped<IOrganizationFileUploadService, OrganizationFileUploadService>();
            _ = service.AddScoped<IActivateUserConvertor, ActivateUserConvertor>();
            _ = service.AddScoped<IActivateUserService, ActivateUserService>();
            _ = service.AddScoped<IActivateUserValidator, ActivateUserValidator>();
            _ = service.AddScoped<ILinkLifeTimeServiceDetailService, LinkLifeTimeServiceDetailService>();
            _ = service.AddScoped<ILinkLifeTimeServiceDetailConvertor, LinkLifeTimeServiceDetailConvertor>();
            _ = service.AddScoped<ILinkLifeTimeDeleteService, LinkLifeTimeDeleteService>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateService, LinkLifeTimeServiceCreateService>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateConvertor, LinkLifeTimeServiceCreateConvertor>();
            _ = service.AddScoped<ILinkLifeTimeServiceCreateValidator, LinkLifeTimeServiceCreateValidator>();
            _ = service.AddScoped<IEmailDetailService, EmailDetailService>();
            _ = service.AddScoped<IEmailDetailConvertor, EmailDetailConvertor>();
            _ = service.AddScoped<IEmailRepository, EmailRepository>();
            _ = service.AddScoped<ISendMailCreateService, SendMailCreateService>();
            _ = service.AddScoped<ISendMailCreateConvertor, SendMailCreateConvertor>();
            _ = service.AddScoped<ISendMailCreateValidator, SendMailCreateValidator>();
            _ = service.AddScoped<ISendMailDetailConvertor, SendMailDetailConvertor>();
            _ = service.AddScoped<ISendMailDetailService, SendMailDetailService>();
            _ = service.AddScoped<ISendMailListConvertor, SendMailListConvertor>();
            _ = service.AddScoped<ISendMailListService, SendMailListService>();
            _ = service.AddScoped<ISendMailUpdateConvertor, SendMailUpdateConvertor>();
            _ = service.AddScoped<ISendMailUpdateService, SendMailUpdateService>();
            _ = service.AddScoped<ISendMailUpdateValidator, SendMailUpdateValidator>();
            _ = service.AddScoped<ICultureDetailCommand, CultureDetailCommand>();
            _ = service.AddScoped<ICultureDetailConvertor, CultureDetailConvertor>();
            _ = service.AddScoped<ILicenseDropDownService, LicenseDropDownService>();
            _ = service.AddScoped<ICourseTypeDropDownService, CourseTypeDropDownService>();
            _ = service.AddScoped<ICourseStatusDropDownService, CourseStatusDropDownService>();
            _ = service.AddScoped<ITimeTableDropDownService, TimeTableDropDownService>();
            _ = service.AddScoped<ICountryDropDownService, CountryDropDown>();
            _ = service.AddScoped<IAnswerModeDropDownService, AnswerModeDropDownService>();
            _ = service.AddScoped<IAddressTypeDropDownService, AddressTypeDropDownService>();
            _ = service.AddScoped<ICourseLessonItemTemplateDropDownService, CourseLessonItemTemplateDropDownService>();
            _ = service.AddScoped<ICultureDropDownService, CultureDropDownService>();
            _ = service.AddScoped<ISendMessageTypeDropDownService, SendMessageTypeDropDownService>();
            _ = service.AddScoped<IQuestionModeDropDownService, QuestionModeDropDownService>();
            _ = service.AddScoped<INoteTypeDropDownService, NoteTypeDropDownService>();
            _ = service.AddScoped<IEmailTypeDropDownService, EmailTypeDropDownService>();
            _ = service.AddScoped<ICountryDropDownConvertor, CountryDropDownConvertor>();
            _ = service.AddScoped<IAddressTypeDropDownConvertor, AddressTypeDropDownConvertor>();
            _ = service.AddScoped<IAnswerModeDropDownConvertor, AnswerModeDropDownConvertor>();
            _ = service.AddScoped<ICourseLessonItemTemplateDropDownConvertor, CourseLessonItemTemplateDropDownConvertor>();
            _ = service.AddScoped<ICourseStatusDropDownConvertor, CourseStatusDropDownConvertor>();
            _ = service.AddScoped<ICourseTypeDropDownConvertor, CourseTypeDropDownConvertor>();
            _ = service.AddScoped<ICultureDropDownConvertor, CultureDropDownConvertor>();
            _ = service.AddScoped<IEmailTypeDropDownConvertor, EmailTypeDropDownConvertor>();
            _ = service.AddScoped<ILicenseDropDownConvertor, LicenseDropDownConvertor>();
            _ = service.AddScoped<INoteTypeDropDownConvertor, NoteTypeDropDownConvertor>();
            _ = service.AddScoped<IQuestionModeDropDownConvertor, QuestionModeDropDownConvertor>();
            _ = service.AddScoped<ISendMessageTypeDropDownConvertor, SendMessageTypeDropDownConvertor>();
            _ = service.AddScoped<ITimeTableDropDownConvertor, TimeTableDropDownConvertor>();
            _ = service.AddScoped<ICertificateDropDownCommand, CertificateDropDownCommand>();
            _ = service.AddScoped<ICertificateDropDownConvertor, CertificateDropDownConvertor>();
            _ = service.AddScoped<ICourseMaterialDropDownService, CourseMaterialDropDownService>();
            _ = service.AddScoped<ICourseMaterialDropDownConvertor, CourseMaterialDropDownConvertor>();
        }

        public static void RegistrationSetup(this IServiceCollection service)
        {
            _ = service.AddScoped<ICreateAdministratorUserService, CreateAdministratorUserService>();
            _ = service.AddScoped<IGetAllEndpointsCommand, GetAllEndpoints>();
            _ = service.AddScoped<ICheckUserService, CheckUserService>();
            //_ = service.AddScoped<IRoleDetailService, RoleDetailService>();
            //_ = service.AddScoped<IRoleDetailConvertor, RoleDetailConvertor>();

        }

        public static void RegisterHangfireJob(this IServiceCollection service)
        {
            _ = service.AddScoped<SendEmailJob>();
        }
    }
}
