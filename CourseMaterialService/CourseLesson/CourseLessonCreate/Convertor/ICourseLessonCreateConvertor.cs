using Core.Base.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Convertor
{
    public interface ICourseLessonCreateConvertor : IBaseCreateConvertor<CourseLessonDbo, CourseLessonCreateDto> { }
}
