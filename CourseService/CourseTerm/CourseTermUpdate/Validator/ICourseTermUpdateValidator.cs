using Core.Base.Validator;
using CourseService.CourseTerm.CourseTermUpdate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermUpdate.Validator
{
    public interface ICourseTermUpdateValidator : IBaseUpdateValidator<CourseTermDbo, CourseTermUpdateDto> { }
}
