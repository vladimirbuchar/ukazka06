using Core.Base.Convertor;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;

namespace Services.StudentAttendance.Convertor
{
    public interface IStudentAttendanceConvertor
        : IBaseConvertor<AttendanceStudentDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto> { }
}
