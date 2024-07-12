using Core.Base.Dto;

namespace Services.Answer.Dto
{
    public class AnswerUpdateDto : UpdateDto
    {
        public string AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
