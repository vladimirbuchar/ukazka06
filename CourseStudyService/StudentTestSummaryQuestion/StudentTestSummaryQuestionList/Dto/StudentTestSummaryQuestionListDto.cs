using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Dto
{
    public class StudentTestSummaryQuestionListDto : ListDto
    {
        public double Score { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
    }
}
