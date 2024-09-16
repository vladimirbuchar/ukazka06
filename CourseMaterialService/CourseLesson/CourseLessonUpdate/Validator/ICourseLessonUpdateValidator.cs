using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Validator
{
    public interface ICourseLessonUpdateValidator : IBaseUpdateValidator<CourseLessonDbo, CourseLessonUpdateDto> { }
}
