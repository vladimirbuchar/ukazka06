using Core.Base.Filter;
using Core.Base.Service;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluationRepository;
using Services.CourseTestEvaluation.Convertor;
using Services.CourseTestEvaluation.Dto;
using Services.CourseTestEvaluation.Validator;

namespace Services.CourseTestEvaluation.Service
{
    public class CourseTestEvaluationService(
        ICourseTestEvaluationConvertor testConvertor,
        ICourseTestEvaluationRepository testRepository,
        ICourseTestEvaluationValidator validator
    )
        : BaseService<
            ICourseTestEvaluationRepository,
            CourseTestEvaluationDbo,
            ICourseTestEvaluationConvertor,
            ICourseTestEvaluationValidator,
            CourseTestEvaluationCreateDto,
            CourseTestEvaluationListDto,
            CourseTestEvaluationDetailDto,
            CourseTestEvaluationUpdateDto,
            FilterRequest
        >(testRepository, testConvertor, validator),
            ICourseTestEvaluationService { }
}
