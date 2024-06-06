using Core.Base.Dto;
using System;

namespace EduServices.Question.Dto
{

    public class QuestionUpdateDto : UpdateDto
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }

    }
}
