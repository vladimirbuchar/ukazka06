using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Dto
{
    public class StudentTestSummaryAnswerListDto : ListDto
    {
        public bool UserAnswer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
