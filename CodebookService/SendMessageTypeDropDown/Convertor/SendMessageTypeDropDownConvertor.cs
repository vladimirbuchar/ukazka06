using CodebookService.SendMessageTypeDropDown.Dto;
using Core.Constants;
using Model.CodeBook;

namespace CodebookService.SendMessageTypeDropDown.Convertor
{
    public class SendMessageTypeDropDownConvertor : ISendMessageTypeDropDownConvertor
    {
        public Task<List<SendMessageTypeDropDownDto>> ConvertToWebModel(List<MessageTemplateTypeDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new SendMessageTypeDropDownDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Name,
                SystemIdentificator = item.SystemIdentificator,
                Disabled = item.SystemIdentificator == SendMessageType.SMS
            })
             .ToList());
        }
    }
}
