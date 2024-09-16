using Core.Base.Validator;
using CourseStudyService.CourseStudy.ResetCourse.Dto;
using Model.Link;

namespace CourseStudyService.CourseStudy.ResetCourse.Validator
{
    public interface IResetCourseValidator : IBaseUpdateValidator<CourseStudentDbo, ResetCourseDto>
    {
    }
}