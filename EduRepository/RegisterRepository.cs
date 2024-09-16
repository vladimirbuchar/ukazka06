using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Microsoft.Extensions.DependencyInjection;
using Repository.Answer;
using Repository.AttendanceStudent;
using Repository.BankOfQuestion;
using Repository.Branch;
using Repository.Certificate;
using Repository.Chat;
using Repository.ClassRoom;
using Repository.Course;
using Repository.CourseLector;
using Repository.CourseLesson;
using Repository.CourseLessonItem;
using Repository.CourseMaterial;
using Repository.CourseStudent;
using Repository.CourseTable;
using Repository.CourseTerm;
using Repository.CourseTermDate;
using Repository.CourseTestBankOfQuestion;
using Repository.CourseTestEvaluation;
using Repository.Email;
using Repository.LicenseChange;
using Repository.LinkLifeTime;
using Repository.MessageTemplate;
using Repository.Note;
using Repository.Notification;
using Repository.Organization;
using Repository.OrganizationCulture;
using Repository.OrganizationHours;
using Repository.OrganizationHoursRepository;
using Repository.OrganizationRole;
using Repository.OrganizationSetting;
using Repository.Permissions;
using Repository.Question;
using Repository.Role;
using Repository.Route;
using Repository.SendEmail;
using Repository.StudentEvaluation;
using Repository.StudentGroup;
using Repository.StudentInGroup;
using Repository.StudentInGroupCourseTerm;
using Repository.StudentTestSummary;
using Repository.StudentTestSummaryAnswer;
using Repository.Test;
using Repository.User;
using Repository.UserCertificate;
using Repository.UserInOrganization;

namespace Repository
{
    public static class RegisterRepository
    {
        public static void Register(IServiceCollection service)
        {
            _ = service.AddScoped<IAnswerRepository, AnswerRepository>();
            _ = service.AddScoped<IAttendanceStudentRepository, AttendanceStudentRepository>();
            _ = service.AddScoped<IBankOfQuestionRepository, BankOfQuestionRepository>();
            _ = service.AddScoped<IBranchRepository, BranchRepository>();
            _ = service.AddScoped<ICertificateRepository, CertificateRepository>();
            _ = service.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            _ = service.AddScoped<ICourseRepository, CourseRepository>();
            _ = service.AddScoped<ICourseLectorRepository, CourseLectorRepository>();
            _ = service.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
            _ = service.AddScoped<ICourseLessonItemRepository, CourseLessonItemRepository>();
            _ = service.AddScoped<ICourseMaterialRepository, CourseMaterialRepository>();
            _ = service.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            _ = service.AddScoped<ICourseTableRepository, CourseTableRepository>();
            _ = service.AddScoped<ICourseTermRepository, CourseTermRepository>();
            _ = service.AddScoped<ICourseTermDateRepository, CourseTermDateRepository>();
            _ = service.AddScoped<ICourseTestBankOfQuestionRepository, CourseTestBankOfQuestionRepository>();
            _ = service.AddScoped<ICourseTestEvaluationRepository, CourseTestEvaluationRepository>();
            _ = service.AddScoped<ICourseTestEvaluationRepository, CourseTestEvaluationRepository>();
            _ = service.AddScoped<IEmailRepository, EmailRepository>();
            _ = service.AddScoped<IChatRepository, ChatRepository>();
            _ = service.AddScoped<ILicenseChangeRepository, LicenseChangeRepository>();
            _ = service.AddScoped<ILinkLifeTimeRepository, LinkLifeTimeRepository>();
            _ = service.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();
            _ = service.AddScoped<INoteRepository, NoteRepository>();
            _ = service.AddScoped<INotificationRepository, NotificationRepository>();
            _ = service.AddScoped<IOrganizationRepository, OrganizationRepository>();
            _ = service.AddScoped<IOrganizationSettingRepository, OrganizationSettingRepository>();
            _ = service.AddScoped<IOrganizationStudyHourRepository, OrganizationStudyHourRepository>();
            _ = service.AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();
            _ = service.AddScoped<IPermissionsRepository, PermissionsRepository>();
            _ = service.AddScoped<IQuestionRepository, QuestionRepository>();
            _ = service.AddScoped<IRoleRepository, RoleRepository>();
            _ = service.AddScoped<IRouteRepository, RouteRepository>();
            _ = service.AddScoped<ISendEmailRepository, SendEmailRepository>();
            _ = service.AddScoped<IStudentEvaluationRepository, StudentEvaluationRepository>();
            _ = service.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
            _ = service.AddScoped<IStudentInGroupRepository, StudentInGroupRepository>();
            _ = service.AddScoped<IStudentInGroupCourseTermRepository, StudentInGroupCourseTermRepository>();
            _ = service.AddScoped<IStudentTestSummaryRepository, StudentTestSummaryRepository>();
            _ = service.AddScoped<IStudentTestSummaryAnswerRepository, StudentTestSummaryAnswerRepository>();
            _ = service.AddScoped<ITestRepository, TestRepository>();
            _ = service.AddScoped<IUserRepository, UserRepository>();
            _ = service.AddScoped<IUserCertificateRepository, UserCertificateRepository>();
            _ = service.AddScoped<IUserInOrganizationRepository, UserInOrganizationRepository>();
            _ = service.AddScoped(typeof(ICodeBookRepository<>), typeof(CodeBookRepository<>));
            _ = service.AddScoped(typeof(IFileUploadRepository<>), typeof(FileUploadRepository<>));
            _ = service.AddScoped<IOrganizationCultureRepository, OrganizationCultureRepository>();

        }
    }
}
