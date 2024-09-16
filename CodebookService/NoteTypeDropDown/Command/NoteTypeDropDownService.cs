using CodebookService.NoteTypeDropDown.Convertor;
using CodebookService.NoteTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.NoteTypeDropDown.Command
{
    public class NoteTypeDropDownService : BaseDropDownCommand<NoteTypeDbo, ICodeBookRepository<NoteTypeDbo>, NoteTypeDropDownDto, INoteTypeDropDownConvertor>, INoteTypeDropDownService
    {
        public NoteTypeDropDownService(ICodeBookRepository<NoteTypeDbo> repository, INoteTypeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
