using Core.Base.Filter;

namespace BankOfQuestionService.Question.QuestionList.Filter
{
    public class QuestionFilter : RequestFilter
    {
        public string? Question { get; set; }
        public List<Guid> AnswerModeId { get; set; } = [];
        public List<Guid> QuestionModeId { get; set; } = [];
    }
}
