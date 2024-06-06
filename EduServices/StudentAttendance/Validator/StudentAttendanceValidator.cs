using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.AttendanceStudentRepository;
using EduRepository.CourseStudentRepository;
using EduServices.StudentAttendance.Dto;
using Model.Tables.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Validator
{
    public class StudentAttendanceValidator(IStudentAttendanceRepository repository, ICourseStudentRepository courseStudentRepository)
        : BaseValidator<StudentAttendanceDbo, IStudentAttendanceRepository, StudentAttendanceCreateDto, StudentAttendanceDetailDto>(repository),
            IStudentAttendanceValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;

        public override Result<StudentAttendanceDetailDto> IsValid(StudentAttendanceCreateDto create)
        {
            Result<StudentAttendanceDetailDto> validate = new();
            if (_courseStudentRepository.GetEntity(create.StudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE_STUDENT, GlobalValue.NOT_EXISTS));
            }
            if (_courseStudentRepository.GetEntity(create.CourseTermDateId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE_TERM_DATE, GlobalValue.NOT_EXISTS));
            }
            if (_courseStudentRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE_TERM, GlobalValue.NOT_EXISTS));
            }

            return validate;
        }
    }
}
