using Core.Base.Command.Update;
using CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Command
{
    public interface ICourseLessonUpdatePositionService : IBaseUpdateCommand<CourseLessonDbo, CourseLessonUpdatePositionDto> { }
}
