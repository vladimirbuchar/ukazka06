using Core.Base.Dto;

namespace EduServices.CourseTestEvaluation.Dto
{
    public class CourseTestEvaluationListDto : ListDto
    {
        public int? PointFrom { get; set; }
        public int? PointTo { get; set; }
        public string Evaluation { get; set; }
    }
}
