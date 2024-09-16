using Core.Base.Command.Update;
using CourseService.CourseTerm.CourseTermUpdate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermUpdate.Command
{
    public interface ICourseTermUpdateService : IBaseUpdateCommand<CourseTermDbo, CourseTermUpdateDto> { }
}
