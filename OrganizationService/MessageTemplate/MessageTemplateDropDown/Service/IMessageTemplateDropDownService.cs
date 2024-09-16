using Core.Base.Command.DropDown;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDropDown.Service
{
    public interface IMessageTemplateDropDownService : IBaseDropDownCommand<MessageTemplateDbo, MessageTemplateDropDownDto>
    {
    }
}