using Core.Base.Validator;
using Model.Edu.CourseLesson;
using Repository.CourseLessonRepository;
using Services.CourseLesson.Dto;

namespace Services.CourseLesson.Validator
{
    public interface ICourseLessonValidator : IBaseValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto, CourseLessonDetailDto, CourseLessonUpdateDto> { }
}
