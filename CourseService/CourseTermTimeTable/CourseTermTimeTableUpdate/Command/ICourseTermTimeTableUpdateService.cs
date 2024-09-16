using Core.Base.Command.Update;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using Model.Edu.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Command
{
    public interface ICourseTermTimeTableUpdateService : IBaseUpdateCommand<CourseTermDateDbo, CourseTermTimeTableUpdateDto> { }
}
