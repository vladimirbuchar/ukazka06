using Core.Base.Convertor;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateList.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Convertor
{
    public interface IMessageTemplateListConvertor : IBaseListConvertor<MessageTemplateDbo, MessageListDto> { }
}
