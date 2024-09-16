using Core.Base.Command.Restore;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationRestore.Command
{
    public class StudentEvaluationRestoreService : BaseRestoreCommand<StudentEvaluationDbo, IStudentEvaluationRepository>, IStudentEvaluationRestoreService
    {
        public StudentEvaluationRestoreService(IStudentEvaluationRepository repository) : base(repository)
        {
        }
    }
}
