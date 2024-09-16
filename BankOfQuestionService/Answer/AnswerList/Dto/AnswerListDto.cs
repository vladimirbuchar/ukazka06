using Core.Base.Dto;

namespace BankOfQuestionService.Answer.AnswerList.Dto
{
    public class AnswerListDto : ListDto
    {
        public string Answer { get; set; } = string.Empty;
        public bool IsTrueAnswer { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}
