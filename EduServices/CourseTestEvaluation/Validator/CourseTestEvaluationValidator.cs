using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseMaterialRepository;
using EduRepository.CourseTestEvaluationRepository;
using EduRepository.TestRepository;
using EduServices.CourseTestEvaluation.Dto;
using Model.Edu.CourseTestEvaluation;

namespace EduServices.CourseTestEvaluation.Validator
{
    public class CourseTestEvaluationValidator(ICourseTestEvaluationRepository repository, ITestRepository testRepository, ICourseMaterialRepository courseMaterialRepository)
        : BaseValidator<CourseTestEvaluationDbo, ICourseTestEvaluationRepository, CourseTestEvaluationCreateDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto>(repository),
            ICourseTestEvaluationValidator
    {
        private readonly ITestRepository _testRepository = testRepository;
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;

        public override Result<CourseTestEvaluationDetailDto> IsValid(CourseTestEvaluationCreateDto create)
        {
            Result<CourseTestEvaluationDetailDto> result = new();
            if (_testRepository.GetEntity(create.TestId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_TEST, GlobalValue.NOT_EXISTS));
            }
            if (_courseMaterialRepository.GetEntity(create.MaterialId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_MATERIAL, GlobalValue.NOT_EXISTS));
            }
            return result;
        }
    }
}
