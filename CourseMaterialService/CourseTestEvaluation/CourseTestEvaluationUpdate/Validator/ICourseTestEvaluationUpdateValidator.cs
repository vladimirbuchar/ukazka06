using Core.Base.Validator;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Validator
{
    public interface ICourseTestEvaluationUpdateValidator : IBaseUpdateValidator<CourseTestEvaluationDbo, CourseTestEvaluationUpdateDto> { }
}
