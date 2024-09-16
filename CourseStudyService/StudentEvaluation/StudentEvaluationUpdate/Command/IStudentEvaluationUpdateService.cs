using Core.Base.Command.Update;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Command
{
    public interface IStudentEvaluationUpdateService : IBaseUpdateCommand<StudentEvaluationDbo, StudentEvaluationUpdateDto>
    {
    }
}