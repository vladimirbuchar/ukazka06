using CodebookService.NoteTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.NoteTypeDropDown.Command
{
    public interface INoteTypeDropDownService : IBaseDropDownCommand<NoteTypeDbo, NoteTypeDropDownDto>
    {
    }
}