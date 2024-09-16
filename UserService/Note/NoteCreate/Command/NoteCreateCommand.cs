using Core.Base.Command.Create;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteCreate.Convertor;
using UserService.Note.NoteCreate.Dto;
using UserService.Note.NoteCreate.Validator;

namespace UserService.Note.NoteCreate.Command
{
    public class NoteCreateCommand : BaseCreateCommand<NoteDbo, INoteRepository, NoteCreateDto, INoteCreateConvertor, INoteCreateValidator>, INoteCreateCommand
    {
        public NoteCreateCommand(INoteRepository repository, INoteCreateConvertor convertor, INoteCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
