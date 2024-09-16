using Core.Base.Command.Update;
using CourseService.Course.CourseUpdate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseUpdate.Command
{
    public interface ICourseUpdateService : IBaseUpdateCommand<CourseDbo, CourseUpdateDto> { }
}
