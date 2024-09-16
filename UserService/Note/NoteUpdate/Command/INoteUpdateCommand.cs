using Core.Base.Command.Update;
using Model.Edu.Note;
using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteUpdate.Command
{
    public interface INoteUpdateCommand : IBaseUpdateCommand<NoteDbo, NoteUpdateDto>
    {
    }
}