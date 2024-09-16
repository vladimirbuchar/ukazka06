using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudent;
using Repository.CourseStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Validator
{
    public class StudentAttendanceCreateValidator : BaseCreateValidator<StudentAttendanceDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto>, IStudentAttendanceCreateValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        public StudentAttendanceCreateValidator(IAttendanceStudentRepository repository, ICourseStudentRepository courseStudentRepository) : base(repository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public override async Task<ResultInsert> IsValid(StudentAttendanceCreateDto create)
        {
            ResultInsert validate = new();
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
