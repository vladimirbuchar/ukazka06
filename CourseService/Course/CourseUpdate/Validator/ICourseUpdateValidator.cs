using Core.Base.Validator;
using CourseService.Course.CourseUpdate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseUpdate.Validator
{
    public interface ICourseUpdateValidator : IBaseUpdateValidator<CourseDbo, CourseUpdateDto> { }
}
