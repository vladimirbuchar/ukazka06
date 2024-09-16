using CodebookService.SendMessageTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.SendMessageTypeDropDown.Command
{
    public interface ISendMessageTypeDropDownService : IBaseDropDownCommand<MessageTemplateTypeDbo, SendMessageTypeDropDownDto>
    {
    }
}