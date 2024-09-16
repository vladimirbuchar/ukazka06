using Core.Base.Command.Detail;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteDetail.Convertor;
using UserService.Note.NoteDetail.Dto;

namespace UserService.Note.NoteDetail.Command
{
    public class NoteDetailCommand : BaseDetailCommand<NoteDbo, INoteRepository, NoteDetailDto, INoteDetailConvertor>, INoteDetailCommand
    {
        public NoteDetailCommand(INoteRepository repository, INoteDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
