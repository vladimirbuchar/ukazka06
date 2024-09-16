using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Convertor
{
    public class MessageTemplateUpdateConvertor : IMessageTemplateUpdateConvertor
    {
        public Task<MessageTemplateDbo> ConvertToBussinessEntity(MessageUpdateDto update, MessageTemplateDbo entity, string culture)
        {
            entity.SendMessageTranslations = entity.SendMessageTranslations.PrepareTranslation(update.Name, update.Html, update.CultureId);
            entity.Reply = update.Reply;
            entity.SendMessageTypeId = update.SendMessageTypeId;
            return Task.FromResult(entity);
        }
    }
}
