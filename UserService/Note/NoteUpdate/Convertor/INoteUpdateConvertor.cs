using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteUpdate.Convertor
{
    public interface INoteUpdateConvertor : IBaseUpdateConvertor<NoteDbo, NoteUpdateDto>
    {
    }
}