using Core.Base.Validator;
using CourseService.Course.CourseCreate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseCreate.Validator
{
    public interface ICourseCreateValidator : IBaseCreateValidator<CourseDbo, CourseCreateDto> { }
}
