using Core.Base.Service;
using EduServices.StudentAttendance.Dto;
using Model.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Service
{
    public interface IStudentAttendanceService : IBaseService<AttendanceStudentDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto> { }
}
