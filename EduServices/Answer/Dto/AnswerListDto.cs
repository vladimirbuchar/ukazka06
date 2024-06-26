﻿using System;
using Core.Base.Dto;

namespace EduServices.Answer.Dto
{
    public class AnswerListDto : ListDto
    {
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid? FileId { get; set; }
        public string FileName { get; set; }
        public string PreivewUrl { get; set; }
    }
}
