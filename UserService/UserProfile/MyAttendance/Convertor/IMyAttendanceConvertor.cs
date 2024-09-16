using Core.Base.Convertor;
using Model.Link;
using UserService.UserProfile.MyAttendance.Dto;

namespace UserService.UserProfile.MyAttendance.Convertor
{
    public interface IMyAttendanceConvertor : IBaseListConvertor<CourseStudentDbo, MyAttendanceListDto> { }
}
