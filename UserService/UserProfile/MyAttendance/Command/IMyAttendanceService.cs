using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Link;
using UserService.UserProfile.MyAttendance.Dto;

namespace UserService.UserProfile.MyAttendance.Command
{
    public interface IMyAttendanceService : IBaseListCommand<CourseStudentDbo, MyAttendanceListDto, RequestFilter> { }
}
