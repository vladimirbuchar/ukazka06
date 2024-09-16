using Core.Base.Command.Restore;
using Model.Edu.Note;
using Repository.Note;

namespace UserService.Note.NoteRestore.Command
{
    public class NoteRestoreCommand : BaseRestoreCommand<NoteDbo, INoteRepository>, INoteRestoreCommand
    {
        public NoteRestoreCommand(INoteRepository repository) : base(repository)
        {
        }
    }
}
