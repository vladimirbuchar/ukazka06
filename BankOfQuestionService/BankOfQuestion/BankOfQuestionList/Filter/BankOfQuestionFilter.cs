using Core.Base.Filter;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Filter
{
    public class BankOfQuestionFilter : RequestFilter
    {
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
    }
}
