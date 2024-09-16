using Core.Base.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Convertor
{
    public interface IStudentEvaluationCreateConvertor : IBaseCreateConvertor<StudentEvaluationDbo, StudentEvaluationCreateDto>
    {
    }
}