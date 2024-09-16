using Core.Base.Dto;

namespace BankOfQuestionService.Answer.AnswerUpdate.Dto
{
    public class AnswerUpdateDto : UpdateDto
    {
        public string? AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
