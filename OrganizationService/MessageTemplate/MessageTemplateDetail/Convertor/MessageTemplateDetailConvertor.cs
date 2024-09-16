using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDetail.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDetail.Convertor
{
    public class MessageTemplateDetailConvertor : IMessageTemplateDetailConvertor
    {
        public Task<MessageDetailDto> ConvertToWebModel(MessageTemplateDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new MessageDetailDto()
                {
                    Html = detail.SendMessageTranslations.FindTranslation(culture).Html,
                    Id = detail.Id,
                    Name = detail.SendMessageTranslations.FindTranslation(culture).Subject,
                    Reply = detail.Reply,
                    SendMessageType = detail.SendMessageTypeId,
                }
            );
        }
    }
}
