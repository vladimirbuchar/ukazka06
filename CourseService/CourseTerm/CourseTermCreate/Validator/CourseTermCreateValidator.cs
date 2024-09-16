using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseService.CourseTerm.CourseTermCreate.Dto;
using Model.CodeBook;
using Model.Edu.ClassRoom;
using Model.Edu.CourseTerm;
using Repository.ClassRoom;
using Repository.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Validator
{
    public class CourseTermCreateValidator
        : BaseCreateValidator<CourseTermDbo, ICourseTermRepository, CourseTermCreateDto>,
            ICourseTermCreateValidator
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ICodeBookRepository<TimeTableDbo> _timeTables;

        public CourseTermCreateValidator(
            ICourseTermRepository repository,
            IClassRoomRepository classRoomRepository,
            ICodeBookRepository<TimeTableDbo> timeTables
        )
            : base(repository)
        {
            _classRoomRepository = classRoomRepository;
            _timeTables = timeTables;
        }

        public override async Task<ResultInsert> IsValid(CourseTermCreateDto create)
        {
            ResultInsert validation = new();
            IsValidCourseDate(create.ActiveFrom, create.ActiveTo, create.RegistrationFrom, create.RegistrationTo, validation);
            ClassRoomDbo classRoomDetail = await _classRoomRepository.GetEntity(create.ClassRoomId.GetValueOrDefault());
            IsValidStudentCount(
                create.MinimumStudents,
                create.MaximumStudents,
                classRoomDetail != null ? classRoomDetail.MaxCapacity : 0,
                validation
            );
            TimeTableDbo from = await _timeTables.GetEntity(false, x => x.Id == create.TimeFromId);
            TimeTableDbo to = await _timeTables.GetEntity(false, x => x.Id == create.TimeToId);
            int priorityFrom = from == null ? 0 : from.Priority;
            int priorityTo = to == null ? 0 : to.Priority;
            if (priorityTo < priorityFrom)
            {
                validation.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, Constants.END_TIME_IS_LESS_THAN_START_TIME)
                );
            }
            return validation;
        }

        private static void IsValidCourseDate(
            DateTime? activeFrom,
            DateTime? activeTo,
            DateTime? registrationFrom,
            DateTime? registrationTo,
            Result result
        )
        {
            if (registrationFrom != null && registrationTo != null && registrationTo < registrationFrom)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, Constants.REGISTRATION_TO_IS_SMALLER_THEN_REGISTRATION_FROM)
                );
            }
            if (activeFrom != null && activeTo != null && activeTo < activeFrom)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, Constants.ACTIVE_TO_IS_SMALLER_THEN_ACTIVE_FROM)
                );
            }
        }

        private static void IsValidStudentCount(int minimumStudent, int maximumStudent, int classRoomCapacity, Result result)
        {
            if (maximumStudent < minimumStudent)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, Constants.MAXIMUM_STUDENTS_IS_LESS_THEN_MINIMUM_STUDENTS)
                );
            }
            if (maximumStudent > classRoomCapacity && classRoomCapacity > 0)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, Constants.MAXIMUM_STUDENTS_IS_MORE_THEN_CAPACITY_CLASS_ROOM)
                );
            }
        }
    }
}
