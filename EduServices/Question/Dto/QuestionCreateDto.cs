using Core.Base.Dto;
using System;

namespace Services.Question.Dto
{
    public class QuestionCreateDto : CreateDto
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }
    }


}
