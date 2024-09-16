using Core.Base.Command.Update;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;
using Model.Edu.CourseTest;

namespace CourseMaterialService.CourseLesson.CourseTestUpdate.Command
{
    public interface ICourseTestUpdateService : IBaseUpdateCommand<CourseTestDbo, CourseTestUpdateDto> { }
}
