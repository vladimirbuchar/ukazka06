using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Convertor
{
    public class MessageTemplateCreateConvertor : IMessageTemplateCreateConvertor
    {
        public Task<MessageTemplateDbo> ConvertToBussinessEntity(MessageCreateDto create, string culture)
        {
            MessageTemplateDbo sendMessage =
                new()
                {
                    OrganizationId = create.OrganizationId,
                    Reply = create.Reply,
                    SendMessageTypeId = create.SendMessageTypeId
                };
            sendMessage.SendMessageTranslations = sendMessage.SendMessageTranslations.PrepareTranslation(create.Name, create.Html, create.CultureId);
            return Task.FromResult(sendMessage);
        }
    }
}
