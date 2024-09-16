using Core.Base.Validator;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Validator
{
    public interface ICourseTestEvaluationCreateValidator : IBaseCreateValidator<CourseTestEvaluationDbo, CourseTestEvaluationCreateDto> { }
}
