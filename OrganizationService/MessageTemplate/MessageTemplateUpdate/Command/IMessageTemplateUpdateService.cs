using Core.Base.Command.Update;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Command
{
    public interface IMessageTemplateUpdateService : IBaseUpdateCommand<MessageTemplateDbo, MessageUpdateDto> { }
}
