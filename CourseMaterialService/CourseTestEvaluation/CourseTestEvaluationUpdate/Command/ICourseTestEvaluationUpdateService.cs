using Core.Base.Command.Update;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Command
{
    public interface ICourseTestEvaluationUpdateService : IBaseUpdateCommand<CourseTestEvaluationDbo, CourseTestEvaluationUpdateDto> { }
}
