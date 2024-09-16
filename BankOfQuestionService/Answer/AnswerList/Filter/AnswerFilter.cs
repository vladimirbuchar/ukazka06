using Core.Base.Filter;

namespace BankOfQuestionService.Answer.AnswerList.Filter
{
    public class AnswerFilter : RequestFilter
    {
        public string? Answer { get; set; }
        public bool? IsTrueAnswer { get; set; }
    }
}
