using Core.Base.Convertor;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Commands.StudentAttendanceCreate.Dto;

namespace Services.StudentAttendance.Convertor
{
    public interface IStudentAttendanceConvertor
        : IBaseConvertor<StudentAttendanceDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto> { }
}
