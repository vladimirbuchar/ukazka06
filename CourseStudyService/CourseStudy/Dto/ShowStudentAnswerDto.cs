using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.Dto
{
    public class ShowStudentAnswerDto : ListDto
    {
        public ShowStudentAnswerDto()
        {
            Answer = [];
        }

        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsTrue { get; set; }
        public string AnswerMode { get; set; }
        public List<StudentAswerResult> Answer { get; set; }
    }
}
