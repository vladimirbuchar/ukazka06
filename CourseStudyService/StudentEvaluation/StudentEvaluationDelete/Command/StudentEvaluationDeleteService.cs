using Core.Base.Command.Delete;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationDelete.Command
{
    public class StudentEvaluationDeleteService : BaseDeleteCommand<StudentEvaluationDbo, IStudentEvaluationRepository>, IStudentEvaluationDeleteService
    {
        public StudentEvaluationDeleteService(IStudentEvaluationRepository repository) : base(repository)
        {
        }
    }
}
