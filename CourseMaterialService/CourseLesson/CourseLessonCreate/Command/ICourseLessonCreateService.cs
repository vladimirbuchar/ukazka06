using Core.Base.Command.Create;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Command
{
    public interface ICourseLessonCreateService : IBaseCreateCommand<CourseLessonDbo, CourseLessonCreateDto> { }
}
