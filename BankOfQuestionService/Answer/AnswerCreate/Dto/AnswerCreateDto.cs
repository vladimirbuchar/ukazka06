using Core.Base.Dto;

namespace BankOfQuestionService.Answer.AnswerCreate.Dto
{
    public class AnswerCreateDto : CreateDto
    {
        public Guid QuestionId { get; set; }
        public string? AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
