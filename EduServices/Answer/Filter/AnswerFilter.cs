using Core.Base.Filter;

namespace Services.Answer.Filter
{
    public class AnswerFilter : FilterRequest
    {
        public string Answer { get; set; }
        public bool? IsTrueAnswer { get; set; }
    }
}
