using Core.Base.Filter;
using System;
using System.Collections.Generic;

namespace Services.Question.Filter
{
    public class QuestionFilter : FilterRequest
    {
        public string Question { get; set; }
        public List<Guid> AnswerModeId { get; set; } = [];
        public List<Guid> QuestionModeId { get; set; } = [];
    }
}
