using Core.Base.Command.List;
using CourseService.CourseTermTimeTable.CourseTermTimeTableList.Filter;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.CourseTermTimeTableList.Dto;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableList.Command
{
    public interface ICourseTermTimeTableListService : IBaseListCommand<CourseTermDateDbo, CourseTermTimeTableListDto, CourseTermTimeTableFilter> { }
}
