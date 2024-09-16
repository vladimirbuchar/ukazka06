using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.Dto
{
    public class EvaluateQuestionDto : ListDto
    {
        public EvaluateQuestionDto()
        {
            AnswerId = [];
        }

        public Guid QuestionId { get; set; }
        public List<Guid> AnswerId { get; set; }
        public string TextAnswer { get; set; }
        public string TextManualAnswer { get; set; }
    }
}
