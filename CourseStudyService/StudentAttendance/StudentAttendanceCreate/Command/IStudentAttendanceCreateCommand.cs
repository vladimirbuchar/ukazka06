using Core.Base.Command.Create;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Command
{
    public interface IStudentAttendanceCreateCommand : IBaseCreateCommand<StudentAttendanceDbo, StudentAttendanceCreateDto>
    {
    }
}