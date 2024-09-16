using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateList.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Convertor
{
    public class MessageTemplateListConvertor : IMessageTemplateListConvertor
    {
        public Task<List<MessageListDto>> ConvertToWebModel(List<MessageTemplateDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new MessageListDto()
                {
                    Id = x.Id,
                    Name = x.SendMessageTranslations.FindTranslation(culture)?.Subject,
                    Reply = x.Reply,
                    SendMessageTypeId = x.SendMessageTypeId,
                    SendMessageTypeName = x.SendMessageType.Name
                })
                    .ToList()
            );
        }
    }
}
