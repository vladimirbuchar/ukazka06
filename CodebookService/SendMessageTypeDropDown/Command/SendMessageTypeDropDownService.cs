using CodebookService.SendMessageTypeDropDown.Convertor;
using CodebookService.SendMessageTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.SendMessageTypeDropDown.Command
{
    public class SendMessageTypeDropDownService : BaseDropDownCommand<MessageTemplateTypeDbo, ICodeBookRepository<MessageTemplateTypeDbo>, SendMessageTypeDropDownDto, ISendMessageTypeDropDownConvertor>, ISendMessageTypeDropDownService
    {
        public SendMessageTypeDropDownService(ICodeBookRepository<MessageTemplateTypeDbo> repository, ISendMessageTypeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
