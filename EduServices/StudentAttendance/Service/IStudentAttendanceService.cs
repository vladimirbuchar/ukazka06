using Core.Base.Filter;
using Core.Base.Service;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;

namespace Services.StudentAttendance.Service
{
    public interface IStudentAttendanceService
        : IBaseService<AttendanceStudentDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto, FilterRequest> { }
}
