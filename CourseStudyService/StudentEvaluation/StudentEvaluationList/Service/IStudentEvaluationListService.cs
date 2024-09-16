using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationList.Service
{
    public interface IStudentEvaluationListService : IBaseListCommand<StudentEvaluationDbo, StudentEvaluationListDto, RequestFilter>
    {
    }
}