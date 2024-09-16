using Core.Base.Dto;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationList.Dto
{
    public class StudentEvaluationListDto : ListDto
    {
        public DateTime Date { get; set; }
        public string? Evaluation { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SecondName { get; set; }
        public string? UserEmail { get; set; }
        public Guid StudentId { get; set; }
    }
}
