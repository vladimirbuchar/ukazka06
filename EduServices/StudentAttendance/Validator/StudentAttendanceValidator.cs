using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.AttendanceStudentRepository;
using EduRepository.CourseStudentRepository;
using EduServices.StudentAttendance.Dto;
using Model.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Validator
{
    public class StudentAttendanceValidator(IAttendanceStudentRepository repository, ICourseStudentRepository courseStudentRepository)
        : BaseValidator<AttendanceStudentDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto, StudentAttendanceDetailDto>(repository),
            IStudentAttendanceValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;

        public override Result<StudentAttendanceDetailDto> IsValid(StudentAttendanceCreateDto create)
        {
            Result<StudentAttendanceDetailDto> validate = new();
            if (_courseStudentRepository.GetEntity(create.StudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_STUDENT, GlobalValue.NOT_EXISTS));
            }
            if (_courseStudentRepository.GetEntity(create.CourseTermDateId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_TERM_DATE, GlobalValue.NOT_EXISTS));
            }
            if (_courseStudentRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_TERM, GlobalValue.NOT_EXISTS));
            }
            return validate;
        }
    }
}
