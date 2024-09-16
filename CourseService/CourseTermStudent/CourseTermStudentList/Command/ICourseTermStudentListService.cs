using Core.Base.Command.List;
using CourseService.CourseTermStudent.CourseTermStudentList.Dto;
using CourseService.CourseTermStudent.CourseTermStudentList.Filter;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentList.Command
{
    public interface ICourseTermStudentListService : IBaseListCommand<CourseStudentDbo, CourseTermStudentListDto, CourseTermStudentFilter> { }
}
