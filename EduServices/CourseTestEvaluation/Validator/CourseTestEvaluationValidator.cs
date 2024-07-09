using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseMaterialRepository;
using Repository.CourseTestEvaluationRepository;
using Repository.TestRepository;
using Services.CourseTestEvaluation.Dto;

namespace Services.CourseTestEvaluation.Validator
{
    public class CourseTestEvaluationValidator(
        ICourseTestEvaluationRepository repository,
        ITestRepository testRepository,
        ICourseMaterialRepository courseMaterialRepository
    )
        : BaseValidator<
            CourseTestEvaluationDbo,
            ICourseTestEvaluationRepository,
            CourseTestEvaluationCreateDto,
            CourseTestEvaluationDetailDto,
            CourseTestEvaluationUpdateDto
        >(repository),
            ICourseTestEvaluationValidator
    {
        private readonly ITestRepository _testRepository = testRepository;
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;

        public override Result<CourseTestEvaluationDetailDto> IsValid(CourseTestEvaluationCreateDto create)
        {
            Result<CourseTestEvaluationDetailDto> result = new();
            if (_testRepository.GetEntity(create.TestId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TEST, MessageItem.NOT_EXISTS));
            }
            if (_courseMaterialRepository.GetEntity(create.MaterialId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_MATERIAL, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
