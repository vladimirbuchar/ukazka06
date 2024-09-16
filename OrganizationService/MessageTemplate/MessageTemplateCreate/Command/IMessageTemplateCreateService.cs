using Core.Base.Command.Create;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Command
{
    public interface IMessageTemplateCreateService : IBaseCreateCommand<MessageTemplateDbo, MessageCreateDto> { }
}
