using System;
using System.Collections.Generic;
using Core.Base.Filter;

namespace Services.Question.Filter
{
    public class QuestionFilter : FilterRequest
    {
        public string Question { get; set; }
        public List<Guid>? AnswerModeId { get; set; } = [];
        public List<Guid>? QuestionModeId { get; set; } = [];
    }
}
