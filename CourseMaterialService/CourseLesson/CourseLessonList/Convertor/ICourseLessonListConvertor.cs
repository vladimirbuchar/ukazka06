using Core.Base.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonList.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Convertor
{
    public interface ICourseLessonListConvertor : IBaseListConvertor<CourseLessonDbo, CourseLessonListDto> { }
}
