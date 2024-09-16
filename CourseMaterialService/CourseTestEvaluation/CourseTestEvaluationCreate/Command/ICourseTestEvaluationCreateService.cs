using Core.Base.Command.Create;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Command
{
    public interface ICourseTestEvaluationCreateService : IBaseCreateCommand<CourseTestEvaluationDbo, CourseTestEvaluationCreateDto> { }
}
