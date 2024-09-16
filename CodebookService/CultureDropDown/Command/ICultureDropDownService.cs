using CodebookService.CultureDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.CultureDropDown.Command
{
    public interface ICultureDropDownService : IBaseDropDownCommand<CultureDbo, CultureDropDownDto>
    {
    }
}