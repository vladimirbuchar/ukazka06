using System;
using Core.Base.Dto;

namespace Services.Answer.Dto
{
    public class AnswerUpdateDto : UpdateDto
    {
        public Guid FileId { get; set; }
        public string AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
