using Core.Base.Validator;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Validator
{
    public interface IStudentAttendanceCreateValidator : IBaseCreateValidator<StudentAttendanceDbo, StudentAttendanceCreateDto>
    {
    }
}