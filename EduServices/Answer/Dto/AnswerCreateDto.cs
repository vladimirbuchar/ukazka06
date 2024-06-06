using Core.Base.Dto;
using System;

namespace EduServices.Answer.Dto
{
    public class AnswerCreateDto : CreateDto
    {
        public Guid QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }

    }
}
