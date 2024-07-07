using Core.Base.Validator;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluationRepository;
using Services.CourseTestEvaluation.Dto;

namespace Services.CourseTestEvaluation.Validator
{
    public interface ICourseTestEvaluationValidator
        : IBaseValidator<CourseTestEvaluationDbo, ICourseTestEvaluationRepository, CourseTestEvaluationCreateDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto>
    { }
}
