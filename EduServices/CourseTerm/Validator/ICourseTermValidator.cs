using Core.Base.Validator;
using Model.Edu.CourseTerm;
using Repository.CourseTermRepository;
using Services.CourseTerm.Dto;

namespace Services.CourseTerm.Validator
{
    public interface ICourseTermValidator : IBaseValidator<CourseTermDbo, ICourseTermRepository, CourseTermCreateDto, CourseTermDetailDto, CourseTermUpdateDto> { }
}
