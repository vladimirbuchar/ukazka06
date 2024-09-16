using Core.Base.Validator;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Validator
{
    public interface IMessageTemplateUpdateValidator : IBaseUpdateValidator<MessageTemplateDbo, MessageUpdateDto> { }
}
