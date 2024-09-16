using Core.Base.Dto;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto
{
    public class StudentEvaluationCreateDto : CreateDto
    {
        public string? Evaluation { get; set; }
        public Guid CourseStudentId { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
