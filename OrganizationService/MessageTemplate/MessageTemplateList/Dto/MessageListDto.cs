using Core.Base.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Dto
{
    public class MessageListDto : ListDto
    {
        public string? Name { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string? SendMessageTypeName { get; set; }
        public string? Reply { get; set; }
    }
}
