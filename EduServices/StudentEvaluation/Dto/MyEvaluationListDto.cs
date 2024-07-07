using Core.Base.Dto;
using System;

namespace Services.StudentEvaluation.Dto
{
    public class MyEvaluationListDto : ListDto
    {
        public DateTime Date { get; set; }
        public string Evaluation { get; set; }
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string Email { get; set; }
        public Guid StudentId { get; set; }
    }
}
