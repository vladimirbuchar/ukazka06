using Core.Base.Command.Create;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Command
{
    public interface IStudentEvaluationCreateService : IBaseCreateCommand<StudentEvaluationDbo, StudentEvaluationCreateDto>
    {
    }
}