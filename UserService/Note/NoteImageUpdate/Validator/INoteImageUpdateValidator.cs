using Core.Base.Validator;
using Model.Edu.Note;
using UserService.Note.NoteImageUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Validator
{
    public interface INoteImageUpdateValidator : IBaseUpdateValidator<NoteDbo, NoteImageUpdateDto>
    {
    }
}