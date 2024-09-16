using Core.Base.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDetail.Dto
{
    public class MessageDetailDto : DetailDto
    {
        public string? Name { get; set; }
        public string? Html { get; set; }
        public Guid SendMessageType { get; set; }
        public string? Reply { get; set; }
    }
}
