using CourseStudyService.CourseStudy.ResetCourse.Dto;
using Model.Link;

namespace CourseStudyService.CourseStudy.ResetCourse.Convertor
{
    public class ResetCourseConvertor : IResetCourseConvertor
    {
        public Task<CourseStudentDbo> ConvertToBussinessEntity(ResetCourseDto update, CourseStudentDbo entity, string culture)
        {
            entity.CourseFinish = false;
            return Task.FromResult(entity);
        }
    }
}
