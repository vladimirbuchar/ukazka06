using Core.Base.Command.Create;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Dto;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Validator;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;
using Repository.Test;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Command
{
    public class CourseTestEvaluationCreateService
        : BaseCreateCommand<
            CourseTestEvaluationDbo,
            ICourseTestEvaluationRepository,
            CourseTestEvaluationCreateDto,
            ICourseTestEvaluationCreateConvertor,
            ICourseTestEvaluationCreateValidator
        >,
            ICourseTestEvaluationCreateService
    {
        private readonly ITestRepository _testRepository;

        public CourseTestEvaluationCreateService(
            ITestRepository testRepository,
            ICourseTestEvaluationRepository repository,
            ICourseTestEvaluationCreateConvertor convertor,
            ICourseTestEvaluationCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _testRepository = testRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _testRepository.GetOrganizationId(objectId);
        }
    }
}
