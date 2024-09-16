using Core.Base.Command.Create;
using CourseService.Course.CourseCreate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseCreate.Command
{
    public interface ICourseCreateService : IBaseCreateCommand<CourseDbo, CourseCreateDto> { }
}
