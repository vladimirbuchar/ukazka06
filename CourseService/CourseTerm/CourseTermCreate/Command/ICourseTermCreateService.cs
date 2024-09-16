using Core.Base.Command.Create;
using CourseService.CourseTerm.CourseTermCreate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Command
{
    public interface ICourseTermCreateService : IBaseCreateCommand<CourseTermDbo, CourseTermCreateDto> { }
}
