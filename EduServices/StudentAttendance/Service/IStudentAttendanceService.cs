using Core.Base.Service;
using EduServices.StudentAttendance.Dto;
using Model.Tables.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Service
{
    public interface IStudentAttendanceService : IBaseService<StudentAttendanceDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto> { }
}
