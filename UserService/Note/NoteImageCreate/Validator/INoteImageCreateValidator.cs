using Core.Base.Validator;
using Model.Edu.Note;
using UserService.Note.NoteImageCreate.Dto;

namespace UserService.Note.NoteImageCreate.Validator
{
    public interface INoteImageCreateValidator : IBaseCreateValidator<NoteDbo, NoteImageCreateDto>
    {
    }
}