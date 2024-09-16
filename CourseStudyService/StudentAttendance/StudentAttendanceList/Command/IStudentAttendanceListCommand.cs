using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceList.Command
{
    public interface IStudentAttendanceListCommand : IBaseListCommand<StudentAttendanceDbo, StudentAttendanceListDto, RequestFilter>
    {
    }
}