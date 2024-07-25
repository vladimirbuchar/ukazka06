using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.StudentEvaluation;
using Repository.CourseStudentRepository;
using Repository.CourseTermRepository;
using Repository.StudentEvaluationRepository;
using Services.StudentEvaluation.Dto;
using System.Threading.Tasks;

namespace Services.StudentEvaluation.Validator
{
    public class StudentEvaluationValidator(
        IStudentEvaluationRepository repository,
        ICourseStudentRepository courseStudentRepository,
        ICourseTermRepository courseTermRepository
    )
        : BaseValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto>(repository),
            IStudentEvaluationValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public override async Task<Result> IsValid(StudentEvaluationCreateDto create)
        {
            Result<StudentEvaluationDetailDto> validate = new();
            if (await _courseStudentRepository.GetEntity(create.CourseStudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_STUDENT, MessageItem.NOT_EXISTS));
            }
            if (await _courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, MessageItem.NOT_EXISTS));
            }
            return await Task.FromResult(validate);
        }
    }
}
