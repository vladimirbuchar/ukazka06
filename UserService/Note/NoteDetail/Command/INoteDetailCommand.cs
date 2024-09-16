using Core.Base.Command.Detail;
using Model.Edu.Note;
using UserService.Note.NoteDetail.Dto;

namespace UserService.Note.NoteDetail.Command
{
    public interface INoteDetailCommand : IBaseDetailCommand<NoteDbo, NoteDetailDto>
    {
    }
}