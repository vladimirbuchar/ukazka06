using CodebookService.EmailTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.EmailTypeDropDown.Command
{
    public interface IEmailTypeDropDownService : IBaseDropDownCommand<EmailTypeDbo, EmailDetailServiceDto>
    {
    }
}