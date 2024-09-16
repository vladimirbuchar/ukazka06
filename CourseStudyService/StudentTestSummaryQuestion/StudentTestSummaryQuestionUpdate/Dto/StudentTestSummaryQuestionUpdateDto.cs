using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto
{
    public class StudentTestSummaryQuestionUpdateDto : UpdateDto
    {
        public int Score { get; set; }
        public bool IsTrue { get; set; }
        public Guid StudentTestSummaryId { get; set; }
    }
}
