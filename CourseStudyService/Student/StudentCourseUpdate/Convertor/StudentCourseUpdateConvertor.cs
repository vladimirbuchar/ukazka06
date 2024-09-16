using CourseStudyService.Student.StudentCourseUpdate.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseUpdate.Convertor
{
    public class StudentCourseUpdateConvertor : IStudentCourseUpdateConvertor
    {
        public Task<CourseStudentDbo> ConvertToBussinessEntity(StudentCourseUpdateDto update, CourseStudentDbo entity, string culture)
        {
            entity.CourseFinish = update.CourseFinish;
            return Task.FromResult(entity);
        }
    }
}
