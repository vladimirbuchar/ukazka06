using Core.Base.Convertor;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Convertor
{
    public interface IMessageTemplateCreateConvertor : IBaseCreateConvertor<MessageTemplateDbo, MessageCreateDto> { }
}
