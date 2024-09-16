using Core.Base.Validator;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Validator
{
    public interface ICourseLessonCreateValidator : IBaseCreateValidator<CourseLessonDbo, CourseLessonCreateDto> { }
}
