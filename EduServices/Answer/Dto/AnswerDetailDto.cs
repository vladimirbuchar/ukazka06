using System;
using Core.Base.Dto;

namespace Services.Answer.Dto
{
    public class AnswerDetailDto : DetailDto
    {
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid? FileId { get; set; }
        public string FileName { get; set; }
    }
}
