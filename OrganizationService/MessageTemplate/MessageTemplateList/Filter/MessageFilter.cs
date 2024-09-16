using Core.Base.Filter;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Filter
{
    public class MessageFilter : RequestFilter
    {
        public string? Name { get; set; }
        public List<Guid> SendMessageTypeId { get; set; } = [];
        public string? Reply { get; set; }
    }
}
