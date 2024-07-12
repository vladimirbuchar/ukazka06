using Core.Base.Filter;

namespace Services.BankOfQuestion.Filter
{
    public class BankOfQuestionFilter : FilterRequest
    {
        public string Name { get; set; }
        public bool? IsDefault { get; set; }
    }
}
