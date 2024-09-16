using Core.Base.Command.Create;
using Model.Edu.Note;
using UserService.Note.NoteCreate.Dto;

namespace UserService.Note.NoteCreate.Command
{
    public interface INoteCreateCommand : IBaseCreateCommand<NoteDbo, NoteCreateDto>
    {
    }
}