using Core.Base.Convertor;
using EduServices.StudentAttendance.Dto;
using Model.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Convertor
{
    public interface IStudentAttendanceConvertor : IBaseConvertor<AttendanceStudentDbo, StudentAttendanceCreateDto, StudentAttendanceListDto, StudentAttendanceDetailDto> { }
}
