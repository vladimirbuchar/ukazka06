using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteList.Dto;

namespace UserService.Note.NoteList.Convertor
{
    public interface INoteListConvertor : IBaseListConvertor<NoteDbo, NoteListDto>
    {
    }
}