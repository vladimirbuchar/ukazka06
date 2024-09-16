using CodebookService.NoteTypeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.NoteTypeDropDown.Convertor
{
    public interface INoteTypeDropDownConvertor : IBaseDropDownConvertor<NoteTypeDbo, NoteTypeDropDownDto>
    {
    }
}