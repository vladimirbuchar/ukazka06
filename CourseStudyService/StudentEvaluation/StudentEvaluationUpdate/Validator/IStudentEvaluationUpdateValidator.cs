using Core.Base.Validator;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Validator
{
    public interface IStudentEvaluationUpdateValidator : IBaseUpdateValidator<StudentEvaluationDbo, StudentEvaluationUpdateDto>
    {
    }
}