using Core.Base.Dto;
using System;

namespace Services.Question.Dto
{

    public class QuestionUpdateDto : UpdateDto
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }

    }
}
