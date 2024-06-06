using Core.Base.Dto;
using System;

namespace EduServices.StudentEvaluation.Dto
{
    public class StudentEvaluationCreateDto : CreateDto
    {
        public string Evaluation { get; set; }
        public Guid CourseStudentId { get; set; }
        public Guid CourseTermId { get; set; }

    }
}
