using Core.Base.Validator;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Dto;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Validator
{
    public class CourseTestEvaluationCreateValidator
        : BaseCreateValidator<CourseTestEvaluationDbo, ICourseTestEvaluationRepository, CourseTestEvaluationCreateDto>,
            ICourseTestEvaluationCreateValidator
    {
        public CourseTestEvaluationCreateValidator(ICourseTestEvaluationRepository repository)
            : base(repository) { }
    }
}
