using System;
using Core.Base.Dto;

namespace EduServices.Question.Dto
{
    public class QuestionListDto : ListDto
    {
        public string Question { get; set; }
        public Guid AnswerMode { get; set; }
        public string BankOfQuestionName { get; set; }
        public Guid BankOfQuestionId { get; set; }
    }
}
