using Core.Base.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationList.Convertor
{
    public interface IStudentEvaluationListConvertor : IBaseListConvertor<StudentEvaluationDbo, StudentEvaluationListDto>
    {
    }
}