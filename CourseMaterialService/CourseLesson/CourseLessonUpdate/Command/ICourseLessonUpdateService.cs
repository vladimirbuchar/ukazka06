using Core.Base.Command.Update;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Command
{
    public interface ICourseLessonUpdateService : IBaseUpdateCommand<CourseLessonDbo, CourseLessonUpdateDto> { }
}
