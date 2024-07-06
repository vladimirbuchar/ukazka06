using Core.Base.Service;
using EduRepository.CourseTestEvaluationRepository;
using EduServices.CourseTestEvaluation.Convertor;
using EduServices.CourseTestEvaluation.Dto;
using EduServices.CourseTestEvaluation.Validator;
using Model.Edu.CourseTestEvaluation;

namespace EduServices.CourseTestEvaluation.Service
{
    public class CourseTestEvaluationService(ICourseTestEvaluationConvertor testConvertor, ICourseTestEvaluationRepository testRepository, ICourseTestEvaluationValidator validator)
        : BaseService<
            ICourseTestEvaluationRepository,
            CourseTestEvaluationDbo,
            ICourseTestEvaluationConvertor,
            ICourseTestEvaluationValidator,
            CourseTestEvaluationCreateDto,
            CourseTestEvaluationListDto,
            CourseTestEvaluationDetailDto,
            CourseTestEvaluationUpdateDto
        >(testRepository, testConvertor, validator),
            ICourseTestEvaluationService { }
}
