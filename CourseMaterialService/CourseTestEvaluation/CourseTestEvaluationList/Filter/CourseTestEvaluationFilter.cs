using Core.Base.Filter;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Filter
{
    public class CourseTestEvaluationFilter : RequestFilter
    {
        public int? PointFrom { get; set; }
        public int? PointTo { get; set; }
        public string? Evaluation { get; set; }
    }
}
