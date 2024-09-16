using Core.Base.Validator;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteUpdate.Validate
{
    public class NoteUpdateValidator : BaseUpdateValidator<NoteDbo, INoteRepository, NoteUpdateDto>, INoteUpdateValidator
    {
        public NoteUpdateValidator(INoteRepository repository) : base(repository)
        {
        }
    }
}
