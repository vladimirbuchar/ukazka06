using Core.Base.Command.List;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateList.Dto;
using OrganizationService.MessageTemplate.MessageTemplateList.Filter;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Command
{
    public interface IMessageTemplateListService : IBaseListCommand<MessageTemplateDbo, MessageListDto, MessageFilter> { }
}
