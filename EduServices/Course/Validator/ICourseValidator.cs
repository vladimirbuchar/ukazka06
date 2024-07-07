using Core.Base.Validator;
using Model.Edu.Course;
using Repository.CourseRepository;
using Services.Course.Dto;

namespace Services.Course.Validator
{
    public interface ICourseValidator : IBaseValidator<CourseDbo, ICourseRepository, CourseCreateDto, CourseDetailDto, CourseUpdateDto> { }
}
