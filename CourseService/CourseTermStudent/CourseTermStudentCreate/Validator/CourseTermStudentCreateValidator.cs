using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using Model.Edu.CourseTerm;
using Model.Link;
using Repository.CourseStudent;
using Repository.CourseTerm;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Validator
{
    public class CourseTermStudentCreateValidator
        : BaseCreateValidator<CourseStudentDbo, ICourseStudentRepository, AddCourseTermStudentDto>,
            ICourseTermStudentCreateValidator
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermStudentCreateValidator(ICourseTermRepository courseTermRepository, ICourseStudentRepository repository)
            : base(repository)
        {
            _courseTermRepository = courseTermRepository;
        }

        public override async Task<ResultInsert> IsValid(AddCourseTermStudentDto create)
        {
            ResultInsert result = new();
            await IsValidStudentCount(create.CourseTermId, result);
            return await Task.FromResult(result);
        }

        private async Task IsValidStudentCount(Guid termId, Result result)
        {
            CourseTermDbo term = await _courseTermRepository.GetEntity(termId);
            int maximumStudent = term?.MaximumStudent ?? 0;
            if (maximumStudent > 0)
            {
                if (maximumStudent < await _repository.GetTotalCount(false, x => x.CourseTermId == termId) + 1)
                {
                    result.AddResultStatus(
                        new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.ADD_MORE_STUDENTS_THAN_MAXIMUM)
                    );
                }
            }
        }
    }
}
