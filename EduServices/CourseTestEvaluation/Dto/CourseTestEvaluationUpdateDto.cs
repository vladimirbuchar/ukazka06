using Core.Base.Dto;

namespace Services.CourseTestEvaluation.Dto
{
    public class CourseTestEvaluationUpdateDto : UpdateDto
    {

        public int PointFrom { get; set; }
        public int PointTo { get; set; }
        public string Evaluation { get; set; }
    }

}
