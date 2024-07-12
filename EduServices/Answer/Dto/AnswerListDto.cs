using Core.Base.Dto;

namespace Services.Answer.Dto
{
    public class AnswerListDto : ListDto
    {
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
