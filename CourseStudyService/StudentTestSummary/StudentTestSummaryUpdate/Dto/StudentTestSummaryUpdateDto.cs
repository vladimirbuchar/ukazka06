using Core.Base.Dto;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto
{
    public class StudentTestSummaryUpdateDto : UpdateDto
    {
        public DateTime Finish { get; set; }
        public bool IsSucess { get; set; }
        public bool IsAutomatic { get; set; }
        public double SumScore { get; set; }
    }
}
