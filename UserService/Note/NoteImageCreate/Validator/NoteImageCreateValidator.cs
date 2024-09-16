using Core.Base.Validator;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteImageCreate.Dto;

namespace UserService.Note.NoteImageCreate.Validator
{
    public class NoteImageCreateValidator : BaseCreateValidator<NoteDbo, INoteRepository, NoteImageCreateDto>, INoteImageCreateValidator
    {
        public NoteImageCreateValidator(INoteRepository repository) : base(repository)
        {
        }
    }
}
