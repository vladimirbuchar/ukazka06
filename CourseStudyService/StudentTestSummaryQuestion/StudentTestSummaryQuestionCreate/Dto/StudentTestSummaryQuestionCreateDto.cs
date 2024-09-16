using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto
{
    public class StudentTestSummaryQuestionCreateDto : CreateDto
    {
        public string? Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid QuestionModeId { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public int Position { get; set; }
        public Guid TestQuestionId { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
