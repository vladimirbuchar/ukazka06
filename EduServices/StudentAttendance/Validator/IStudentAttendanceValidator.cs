using Core.Base.Validator;
using EduRepository.AttendanceStudentRepository;
using EduServices.StudentAttendance.Dto;
using Model.Tables.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Validator
{
    public interface IStudentAttendanceValidator : IBaseValidator<AttendanceStudentDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto, StudentAttendanceDetailDto> { }
}
