using System;
using Core.Base.Dto;

namespace Services.CourseTestEvaluation.Dto
{
    public class CourseTestEvaluationCreateDto : CreateDto
    {
        public int PointFrom { get; set; }
        public int PointTo { get; set; }
        public string Evaluation { get; set; }
        public Guid TestId { get; set; }
        public Guid MaterialId { get; set; }
    }
}
