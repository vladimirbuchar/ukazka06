using Core.Base.Convertor;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDetail.Convertor
{
    public interface IMessageTemplateDetailConvertor : IBaseDetailConvertor<MessageTemplateDbo, MessageDetailDto> { }
}
