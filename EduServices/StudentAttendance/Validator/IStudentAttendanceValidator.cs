using Core.Base.Validator;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudentRepository;
using Services.StudentAttendance.Dto;

namespace Services.StudentAttendance.Validator
{
    public interface IStudentAttendanceValidator
        : IBaseValidatorCreate<AttendanceStudentDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto>
    { }
}
