using Core.Base.Command.DropDown;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.Dto;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.MessageTemplateDropDownConvertor;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateDropDown.Service
{
    public class MessageTemplateDropDownService : BaseDropDownCommand<MessageTemplateDbo, IMessageTemplateRepository, MessageTemplateDropDownDto, IMessageTemplateDropDownConvertor>, IMessageTemplateDropDownService
    {
        public MessageTemplateDropDownService(IMessageTemplateRepository repository, IMessageTemplateDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
