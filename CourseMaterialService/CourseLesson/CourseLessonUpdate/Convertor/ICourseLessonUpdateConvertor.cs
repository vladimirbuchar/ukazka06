using Core.Base.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Convertor
{
    public interface ICourseLessonUpdateConvertor : IBaseUpdateConvertor<CourseLessonDbo, CourseLessonUpdateDto> { }
}
