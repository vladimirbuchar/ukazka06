using Core.Base.Command.Create;
using CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Dto;
using Model.Edu.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Command
{
    public interface ICourseTermTimeTableCreateService : IBaseCreateCommand<CourseTermDateDbo, CourseTermTimeTableCreateDto> { }
}
