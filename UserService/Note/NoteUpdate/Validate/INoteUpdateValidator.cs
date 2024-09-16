using Core.Base.Validator;
using Model.Edu.Note;
using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteUpdate.Validate
{
    public interface INoteUpdateValidator : IBaseUpdateValidator<NoteDbo, NoteUpdateDto>
    {
    }
}