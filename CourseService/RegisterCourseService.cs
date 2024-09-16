using CourseService.Course.CourseCreate.Command;
using CourseService.Course.CourseCreate.Convertor;
using CourseService.Course.CourseCreate.Validator;
using CourseService.Course.CourseDelete.Command;
using CourseService.Course.CourseDetail.Command;
using CourseService.Course.CourseDetail.Convertor;
using CourseService.Course.CourseList.Command;
using CourseService.Course.CourseList.Convertor;
using CourseService.Course.CourseRestore.Command;
using CourseService.Course.CourseUpdate.Command;
using CourseService.Course.CourseUpdate.Convertor;
using CourseService.Course.CourseUpdate.Validator;
using CourseService.CourseTerm.CourseTermCreate.Command;
using CourseService.CourseTerm.CourseTermCreate.Convertor;
using CourseService.CourseTerm.CourseTermCreate.Validator;
using CourseService.CourseTerm.CourseTermDelete.Command;
using CourseService.CourseTerm.CourseTermDetail.Command;
using CourseService.CourseTerm.CourseTermDetail.Convertor;
using CourseService.CourseTerm.CourseTermList.Command;
using CourseService.CourseTerm.CourseTermList.Convertor;
using CourseService.CourseTerm.CourseTermRestore.Command;
using CourseService.CourseTerm.CourseTermUpdate.Command;
using CourseService.CourseTerm.CourseTermUpdate.Convertor;
using CourseService.CourseTerm.CourseTermUpdate.Validator;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Command;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Convertor;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Validator;
using CourseService.CourseTermStudent.CourseTermStudentDelete.Command;
using CourseService.CourseTermStudent.CourseTermStudentList.Command;
using CourseService.CourseTermStudent.CourseTermStudentList.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Command;
using CourseService.CourseTermTimeTable.CourseTermTimeTableDelete.Command;
using CourseService.CourseTermTimeTable.CourseTermTimeTableList.Command;
using CourseService.CourseTermTimeTable.CourseTermTimeTableList.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Command;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace CourseService
{
    public static class RegisterCourseService
    {








        public static void RegistrationCourseTermDate(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermTimeTableUpdateService, CourseTermTimeTableUpdateService>();
            _ = service.AddScoped<ICourseTermTimeTableCreateService, CourseTermTimeTableCreateService>();
            _ = service.AddScoped<ICourseTermTimeTableDeleteService, CourseTermTimeTableDeleteService>();
            _ = service.AddScoped<ICourseTermTimeTableListConvertor, CourseTermTimeTableListConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableListService, CourseTermTimeTableListService>();
            _ = service.AddScoped<ICourseTermTimeTableUpdateConvertor, CourseTermTimeTableUpdateConvertor>();
            _ = service.AddScoped<ICourseTermTimeTableUpdatevalidator, CourseTermTimeTableUpdatevalidator>();
        }

        public static void RegistrationCourse(this IServiceCollection service)
        {
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





        public static void RegistrationCourseTerm(this IServiceCollection service)
        {
            _ = service.AddScoped<ICourseTermStudentCreateService, CourseTermStudentCreateService>();
            _ = service.AddScoped<ICourseTermStudentCreateValidator, CourseTermStudentCreateValidator>();
            _ = service.AddScoped<ICourseTermStudentDeleteService, CourseTermStudentDeleteService>();
            _ = service.AddScoped<ICourseTermStudentListConvertor, CourseTermStudentListConvertor>();
            _ = service.AddScoped<ICourseTermStudentListService, CourseTermStudentListService>();
            _ = service.AddScoped<ICourseTermStudentCreateConvertor, CourseTermStudentCreateConvertor>();

        }




        public static void RegistrionCourseStudent(this IServiceCollection service)
        {
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

        }

    }
}
