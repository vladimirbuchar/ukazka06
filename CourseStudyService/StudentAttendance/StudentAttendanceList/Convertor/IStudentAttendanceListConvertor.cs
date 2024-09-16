using Core.Base.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceList.Convertor
{
    public interface IStudentAttendanceListConvertor : IBaseListConvertor<StudentAttendanceDbo, StudentAttendanceListDto>
    {
    }
}