using Core.Base.Dto;
using System;

namespace EduServices.Question.Dto
{
    public class QuestionCreateDto : CreateDto
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }
    }


}
