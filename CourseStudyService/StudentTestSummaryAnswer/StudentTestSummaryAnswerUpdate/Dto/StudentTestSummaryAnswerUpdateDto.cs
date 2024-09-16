using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto
{
    public class StudentTestSummaryAnswerUpdateDto : UpdateDto
    {
        public string Answer { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public bool IsTrue { get; set; }
    }
}
