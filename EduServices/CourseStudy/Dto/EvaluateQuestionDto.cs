using Core.Base.Dto;
using System;
using System.Collections.Generic;

namespace Services.CourseStudy.Dto
{
    public class EvaluateQuestionDto : ListDto
    {
        public EvaluateQuestionDto()
        {
            AnswerId = [];
        }

        public Guid QuestionId { get; set; }
        public List<Guid> AnswerId { get; set; }
        public string TextAnswer { get; set; }
        public string TextManualAnswer { get; set; }
    }
}
