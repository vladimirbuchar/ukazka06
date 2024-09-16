using Core.Base.Validator;
using Model.Edu.Note;
using UserService.Note.NoteCreate.Dto;

namespace UserService.Note.NoteCreate.Validator
{
    public interface INoteCreateValidator : IBaseCreateValidator<NoteDbo, NoteCreateDto>
    {
    }
}