using Core.Base.Command.Delete;
using Model.Edu.Note;
using Repository.Note;

namespace UserService.Note.NoteDelete.Command
{
    public class NoteDeleteCommand : BaseDeleteCommand<NoteDbo, INoteRepository>, INoteDeleteCommand
    {
        public NoteDeleteCommand(INoteRepository repository) : base(repository)
        {
        }
    }
}
