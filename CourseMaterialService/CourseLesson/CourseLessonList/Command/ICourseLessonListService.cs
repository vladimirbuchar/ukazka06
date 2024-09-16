using Core.Base.Command.List;
using CourseMaterialService.CourseLesson.CourseLessonList.Dto;
using CourseMaterialService.CourseLesson.CourseLessonList.Filter;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Command
{
    public interface ICourseLessonListService : IBaseListCommand<CourseLessonDbo, CourseLessonListDto, CourseLessonFilter> { }
}
