using Core.Base.Command;
using Core.Base.Filter;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Commands.StudentAttendanceCreate.Dto;

namespace Services.StudentAttendance.Service
{
    [System.Obsolete]
    public interface IStudentAttendanceService
        : IBaseService<StudentAttendanceDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto, RequestFilter>
    { }
}
