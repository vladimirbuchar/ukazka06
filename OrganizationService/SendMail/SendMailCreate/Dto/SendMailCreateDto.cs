using Core.Base.Dto;

namespace OrganizationService.SendMail.SendMailCreate.Dto
{
    public class SendMailCreateDto : CreateDto
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string PlainTextBody { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
        public string EmailFrom { get; set; } = string.Empty;
        public string EmailFromName { get; set; } = string.Empty;
        public string EmailTo { get; set; } = string.Empty;
        public string EmailToName { get; set; } = string.Empty;
        public string Reply { get; set; } = string.Empty;
        public Guid? OrganizationId { get; set; }
        public List<string> SendEmailAttachments { get; set; } = [];
    }
}
