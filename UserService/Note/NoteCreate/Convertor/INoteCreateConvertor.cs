using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteCreate.Dto;

namespace UserService.Note.NoteCreate.Convertor
{
    public interface INoteCreateConvertor : IBaseCreateConvertor<NoteDbo, NoteCreateDto>
    {
    }
}