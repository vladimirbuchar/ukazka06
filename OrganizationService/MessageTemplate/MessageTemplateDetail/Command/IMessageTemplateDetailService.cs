using Core.Base.Command.Detail;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDetail.Command
{
    public interface IMessageTemplateDetailService : IBaseDetailCommand<MessageTemplateDbo, MessageDetailDto> { }
}
