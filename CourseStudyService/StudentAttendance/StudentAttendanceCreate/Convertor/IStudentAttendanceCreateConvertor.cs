using Core.Base.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Convertor
{
    public interface IStudentAttendanceCreateConvertor : IBaseCreateConvertor<StudentAttendanceDbo, StudentAttendanceCreateDto>
    {
    }
}