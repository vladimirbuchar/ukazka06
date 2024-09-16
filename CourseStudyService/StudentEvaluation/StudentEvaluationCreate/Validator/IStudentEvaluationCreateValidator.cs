using Core.Base.Validator;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Validator
{
    public interface IStudentEvaluationCreateValidator : IBaseCreateValidator<StudentEvaluationDbo, StudentEvaluationCreateDto>
    {
    }
}