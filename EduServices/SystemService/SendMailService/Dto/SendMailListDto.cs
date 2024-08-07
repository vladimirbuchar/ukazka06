﻿using Core.Base.Dto;

namespace Services.SystemService.SendMailService.Dto
{
    public class SendMailListDto : ListDto
    {
        public string Subject { get; set; }
        public bool IsHtml { get; set; } = true;
        public string EmailFrom { get; set; }
        public string EmailFromName { get; set; }
        public string EmailTo { get; set; }
        public string EmailToName { get; set; }
        public bool IsSended { get; set; } = false;
        public string Reply { get; set; }
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}
