using Core.Base.Command.Detail;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Dto;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateDetail.Command
{
    public class MessageTemplateDetailService
        : BaseDetailCommand<MessageTemplateDbo, IMessageTemplateRepository, MessageDetailDto, IMessageTemplateDetailConvertor>,
            IMessageTemplateDetailService
    {
        public MessageTemplateDetailService(IMessageTemplateRepository repository, IMessageTemplateDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
