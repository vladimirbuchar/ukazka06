using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto
{
    public class StudentTestSummaryAnswerCreateDto : CreateDto
    {
        public Guid StudentTestSummaryQuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid TestQuestionAnswerId { get; set; }
        public string? FilePath { get; set; }
    }
}
