using Core.Base.Validator;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Validator
{
    public interface IMessageTemplateCreateValidator : IBaseCreateValidator<MessageTemplateDbo, MessageCreateDto> { }
}
