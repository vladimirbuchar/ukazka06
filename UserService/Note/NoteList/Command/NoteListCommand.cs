using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteList.Convertor;
using UserService.Note.NoteList.Dto;

namespace UserService.Note.NoteList.Command
{
    public class NoteListCommand : BaseListCommand<NoteDbo, INoteRepository, NoteListDto, INoteListConvertor, RequestFilter>, INoteListCommand
    {
        public NoteListCommand(INoteRepository repository, INoteListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
