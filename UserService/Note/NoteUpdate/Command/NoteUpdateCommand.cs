using Core.Base.Command.Update;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteUpdate.Convertor;
using UserService.Note.NoteUpdate.Dto;
using UserService.Note.NoteUpdate.Validate;

namespace UserService.Note.NoteUpdate.Command
{
    public class NoteUpdateCommand : BaseUpdateCommand<NoteDbo, INoteRepository, NoteUpdateDto, INoteUpdateConvertor, INoteUpdateValidator>, INoteUpdateCommand
    {
        public NoteUpdateCommand(INoteRepository repository, INoteUpdateConvertor convertor, INoteUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
