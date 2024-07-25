using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudentRepository;
using Repository.CourseStudentRepository;
using Services.StudentAttendance.Dto;
using System.Threading.Tasks;

namespace Services.StudentAttendance.Validator
{
    public class StudentAttendanceValidator(IAttendanceStudentRepository repository, ICourseStudentRepository courseStudentRepository)
        : BaseValidator<AttendanceStudentDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto>(repository),
            IStudentAttendanceValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;

        public override async Task<Result> IsValid(StudentAttendanceCreateDto create)
        {
            Result<StudentAttendanceDetailDto> validate = new();
            if (await _courseStudentRepository.GetEntity(create.StudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_STUDENT, MessageItem.NOT_EXISTS));
            }
            if (await _courseStudentRepository.GetEntity(create.CourseTermDateId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM_DATE, MessageItem.NOT_EXISTS));
            }
            if (await _courseStudentRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, MessageItem.NOT_EXISTS));
            }
            return validate;
        }
    }
}
