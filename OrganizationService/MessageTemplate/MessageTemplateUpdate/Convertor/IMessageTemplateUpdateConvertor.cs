using Core.Base.Convertor;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Convertor
{
    public interface IMessageTemplateUpdateConvertor : IBaseUpdateConvertor<MessageTemplateDbo, MessageUpdateDto> { }
}
