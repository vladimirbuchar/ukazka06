using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.Dto
{
    public class ShowTestResultDto : ListDto
    {
        public ShowTestResultDto()
        {
            Question = [];
        }

        public double Score { get; set; }
        public DateTime? Finish { get; set; }
        public bool TestCompleted { get; set; }
        public DateTime? StartTime { get; set; }
        public List<ShowTestResultQuestionDto> Question { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
    }
}
