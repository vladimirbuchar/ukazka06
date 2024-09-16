using BankOfQuestionService.Answer.AnswerList.Dto;
using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace BankOfQuestionService.Question.QuestionList.Dto
{
    public class QuestionListDto : ListDto
    {
        public string? Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public string? AnswerModeName { get; set; }
        public Guid QuestionModeId { get; set; }
        public string? QuestionModeName { get; set; }
        [JsonIgnore]
        public bool IsAutomatic { get; set; }
        public int Position { get; set; }
        public string? FileName { get; set; }
        public required List<AnswerListDto> TestQuestionAnswer { get; set; }
    }
}
