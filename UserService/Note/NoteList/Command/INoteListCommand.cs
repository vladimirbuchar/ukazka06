using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.Note;
using UserService.Note.NoteList.Dto;

namespace UserService.Note.NoteList.Command
{
    public interface INoteListCommand : IBaseListCommand<NoteDbo, NoteListDto, RequestFilter>
    {
    }
}