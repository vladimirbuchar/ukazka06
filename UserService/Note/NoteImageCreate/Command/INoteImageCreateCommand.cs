using Core.Base.Command.Create;
using Model.Edu.Note;
using UserService.Note.NoteImageCreate.Dto;

namespace UserService.Note.NoteImageCreate.Command
{
    public interface INoteImageCreateCommand : IBaseCreateCommand<NoteDbo, NoteImageCreateDto>
    {
    }
}