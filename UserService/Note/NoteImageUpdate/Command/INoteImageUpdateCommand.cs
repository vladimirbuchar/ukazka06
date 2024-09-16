using Core.Base.Command.Update;
using Model.Edu.Note;
using UserService.Note.NoteImageUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Command
{
    public interface INoteImageUpdateCommand : IBaseUpdateCommand<NoteDbo, NoteImageUpdateDto>
    {
    }
}