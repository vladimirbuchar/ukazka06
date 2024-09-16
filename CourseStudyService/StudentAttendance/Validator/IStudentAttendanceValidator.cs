using Core.Base.Validator;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Commands.StudentAttendanceCreate.Dto;

namespace Services.StudentAttendance.Validator
{
    public interface IStudentAttendanceValidator : IBaseCreateValidator<StudentAttendanceDbo, StudentAttendanceCreateDto> { }
}
