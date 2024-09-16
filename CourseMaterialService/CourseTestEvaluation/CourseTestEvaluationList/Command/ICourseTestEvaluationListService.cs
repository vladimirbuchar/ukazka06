using Core.Base.Command.List;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Dto;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Filter;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Command
{
    public interface ICourseTestEvaluationListService
        : IBaseListCommand<CourseTestEvaluationDbo, CourseTestEvaluationListDto, CourseTestEvaluationFilter>
    { }
}
