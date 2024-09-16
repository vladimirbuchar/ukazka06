using Core.Base.Validator;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteImageUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Validator
{
    public class NoteImageUpdateValidator : BaseUpdateValidator<NoteDbo, INoteRepository, NoteImageUpdateDto>, INoteImageUpdateValidator
    {
        public NoteImageUpdateValidator(INoteRepository repository) : base(repository)
        {
        }
    }
}
