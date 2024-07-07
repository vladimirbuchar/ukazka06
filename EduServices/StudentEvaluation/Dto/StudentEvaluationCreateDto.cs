using Core.Base.Dto;
using System;

namespace Services.StudentEvaluation.Dto
{
    public class StudentEvaluationCreateDto : CreateDto
    {
        public string Evaluation { get; set; }
        public Guid CourseStudentId { get; set; }
        public Guid CourseTermId { get; set; }

    }
}
