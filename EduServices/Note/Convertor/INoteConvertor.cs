using Core.Base.Convertor;
using Model.Edu.Note;
using Services.Note.Dto;

namespace Services.Note.Convertor
{
    public interface INoteConvertor : IBaseConvertor<NoteDbo, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto> { }
}
