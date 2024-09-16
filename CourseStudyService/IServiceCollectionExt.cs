using CourseStudyService.Chat.ChatCreate.Command;
using CourseStudyService.Chat.ChatCreate.Convertor;
using CourseStudyService.Chat.ChatCreate.Validator;
using CourseStudyService.Chat.ChatDelete.Command;
using CourseStudyService.Chat.ChatList.Command;
using CourseStudyService.Chat.ChatList.Convertor;
using CourseStudyService.Chat.ChatUpdate.Command;
using CourseStudyService.Chat.ChatUpdate.Convertor;
using CourseStudyService.Chat.ChatUpdate.Validator;
using CourseStudyService.Lector.LectorCreate.Command;
using CourseStudyService.Lector.LectorCreate.Convertor;
using CourseStudyService.Lector.LectorCreate.Validator;
using CourseStudyService.Lector.LectorList.Command;
using CourseStudyService.Lector.LectorList.Convertor;
using CourseStudyService.Lector.LectorMultipleDelete.Command;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Command;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Validator;
using CourseStudyService.StudentAttendance.StudentAttendanceDelete.Command;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Command;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceRestore.Command;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Command;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Validator;
using CourseStudyService.StudentEvaluation.StudentEvaluationDelete.Command;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Service;
using CourseStudyService.StudentEvaluation.StudentEvaluationRestore.Command;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Command;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Validator;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Command;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Convertor;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Validator;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermMultipleDelete.Command;
using Microsoft.Extensions.DependencyInjection;

namespace CourseStudyService
{
    public static class RegisterCourseStudyService
    {
        public static void RegistrationCourseTestEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<ILectorCreateConvertor, LectorCreateConvertor>();
            _ = service.AddScoped<ILectorCreateService, LectorCreateService>();
            _ = service.AddScoped<ILectorCreateValidator, LectorCreateValidator>();
            _ = service.AddScoped<ILectorListService, LectorListService>();
            _ = service.AddScoped<ILectorListConvertor, LectorListConvertor>();

        }





        public static void RegistrionCourseStudent(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentInGroupCourseTermCreateService, StudentInGroupCourseTermCreateService>();
            _ = service.AddScoped<IStudentInGroupCourseTermCreateConvertor, StudentInGroupCourseTermCreateConvertor>();
            _ = service.AddScoped<IStudentInGroupCourseTermCreateValidator, StudentInGroupCourseTermCreateValidator>();
            _ = service.AddScoped<ILectorMultipleDeleteService, LectorMultipleDeleteService>();
            _ = service.AddScoped<IStudentInGroupCourseTermMultipleDeleteService, StudentInGroupCourseTermMultipleDeleteService>();
        }
















        public static void RegisterChat(this IServiceCollection service)
        {
            _ = service.AddScoped<IChatCreateCommand, ChatCreateCommand>();
            _ = service.AddScoped<IChatCreateConvertor, ChatCreateConvertor>();
            _ = service.AddScoped<IChatCreateValidator, ChatCreateValidator>();
            _ = service.AddScoped<IChatDeleteCommand, ChatDeleteCommand>();
            _ = service.AddScoped<IChatListCommand, ChatListCommand>();
            _ = service.AddScoped<IChatListConvertor, ChatListConvertor>();
            _ = service.AddScoped<IChatUpdateCommand, ChatUpdateCommand>();
            _ = service.AddScoped<IChatUpdateConvertor, ChatUpdateConvertor>();
            _ = service.AddScoped<IChatUpdateValidator, ChatUpdateValidator>();

        }


        public static void RegistrationAttendanceStudent(this IServiceCollection service)
        {
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
            _ = service.AddScoped<IStudentEvaluationRestoreService, StudentEvaluationRestoreService>();
            _ = service.AddScoped<IStudentEvaluationUpdateConvertor, StudentEvaluationUpdateConvertor>();
            _ = service.AddScoped<IStudentEvaluationUpdateService, StudentEvaluationUpdateService>();
            _ = service.AddScoped<IStudentEvaluationUpdateValidator, StudentEvaluationUpdateValidator>();
        }

        public static void RegistrationStudentEvaluation(this IServiceCollection service)
        {
            _ = service.AddScoped<IStudentEvaluationCreateConvertor, StudentEvaluationCreateConvertor>();
            _ = service.AddScoped<IStudentEvaluationCreateService, StudentEvaluationCreateService>();
            _ = service.AddScoped<IStudentEvaluationCreateValidator, StudentEvaluationCreateValidator>();
            _ = service.AddScoped<IStudentEvaluationDeleteService, StudentEvaluationDeleteService>();
            _ = service.AddScoped<IStudentEvaluationListConvertor, StudentEvaluationListConvertor>();
            _ = service.AddScoped<IStudentEvaluationListService, StudentEvaluationListService>();
        }


    }
}
