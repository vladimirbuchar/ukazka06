using Core.Base.Validator;
using EduRepository.CourseLessonRepository;
using EduServices.CourseLesson.Dto;
using Model.Tables.Edu.CourseLesson;

namespace EduServices.CourseLesson.Validator
{
    public interface ICourseLessonValidator : IBaseValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto, CourseLessonDetailDto, CourseLessonUpdateDto> { }
}
