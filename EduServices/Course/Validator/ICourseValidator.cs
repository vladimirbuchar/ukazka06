using Core.Base.Validator;
using EduRepository.CourseRepository;
using EduServices.Course.Dto;
using Model.Tables.Edu.Course;

namespace EduServices.Course.Validator
{
    public interface ICourseValidator : IBaseValidator<CourseDbo, ICourseRepository, CourseCreateDto, CourseDetailDto, CourseUpdateDto> { }
}
