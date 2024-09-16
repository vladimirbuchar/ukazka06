using CodebookService.SendMessageTypeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.SendMessageTypeDropDown.Convertor
{
    public interface ISendMessageTypeDropDownConvertor : IBaseDropDownConvertor<MessageTemplateTypeDbo, SendMessageTypeDropDownDto>
    {
    }
}