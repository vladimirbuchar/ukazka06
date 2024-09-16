using Core.Base.Command.Delete;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationDelete.Command
{
    public class CourseTestEvaluationDeleteService
        : BaseDeleteCommand<CourseTestEvaluationDbo, ICourseTestEvaluationRepository>,
            ICourseTestEvaluationDeleteService
    {
        public CourseTestEvaluationDeleteService(ICourseTestEvaluationRepository repository)
            : base(repository) { }
    }
}
