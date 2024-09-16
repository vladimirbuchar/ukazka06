using Core.Base.Command.Detail;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Dto;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonDetail.Command
{
    public interface ICourseLessonDetailService : IBaseDetailCommand<CourseLessonDbo, CourseLessonDetailDto> { }
}
