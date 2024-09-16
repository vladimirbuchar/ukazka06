using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteImageUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Convertor
{
    public interface INoteImageUpdateConvertor : IBaseUpdateConvertor<NoteDbo, NoteImageUpdateDto>
    {
    }
}