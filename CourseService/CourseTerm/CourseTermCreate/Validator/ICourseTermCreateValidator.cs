using Core.Base.Validator;
using CourseService.CourseTerm.CourseTermCreate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Validator
{
    public interface ICourseTermCreateValidator : IBaseCreateValidator<CourseTermDbo, CourseTermCreateDto> { }
}
