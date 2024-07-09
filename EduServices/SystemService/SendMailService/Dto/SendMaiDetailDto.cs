using Core.Base.Dto;
using System.Collections.Generic;

namespace Services.SystemService.SendMailService.Dto
{
    public class SendMaiDetailDto : DetailDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; } = true;
        public string EmailFrom { get; set; }
        public string EmailFromName { get; set; }
        public string EmailTo { get; set; }
        public string EmailToName { get; set; }
        public bool IsSended { get; set; } = false;
        public string Reply { get; set; }
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; }
        public string PlainTextBody { get; set; }
        public List<SendMaiDetailAttachmentsDto> Attagments { get; set; } = [];
    }
    public class SendMaiDetailAttachmentsDto
    {
        public string Attachment { get; set; }
    }

}
