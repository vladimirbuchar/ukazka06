using Core.Base.Validator;
using CourseStudyService.Student.StudentCourseUpdate.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseUpdate.Validator
{
    public interface IStudentCourseUpdateValidator : IBaseUpdateValidator<CourseStudentDbo, StudentCourseUpdateDto>
    {
    }
}