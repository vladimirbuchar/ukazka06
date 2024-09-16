using Core.Base.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Convertor
{
    public interface IStudentEvaluationUpdateConvertor : IBaseUpdateConvertor<StudentEvaluationDbo, StudentEvaluationUpdateDto>
    {
    }
}