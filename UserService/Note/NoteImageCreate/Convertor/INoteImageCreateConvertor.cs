using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteImageCreate.Dto;

namespace UserService.Note.NoteImageCreate.Convertor
{
    public interface INoteImageCreateConvertor : IBaseCreateConvertor<NoteDbo, NoteImageCreateDto>
    {
    }
}