using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateDropDown.Dto;

namespace OrganizationService.MessageTemplate.MessageTemplateDropDown.MessageTemplateDropDownConvertor
{
    public class MessageTemplateDropDownConvertor : IMessageTemplateDropDownConvertor
    {
        public Task<List<MessageTemplateDropDownDto>> ConvertToWebModel(List<MessageTemplateDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new MessageTemplateDropDownDto()
            {
                Id = x.Id,
                Name = x.SendMessageTranslations.FindTranslation(culture).Subject

            }).ToList());
        }
    }
}
