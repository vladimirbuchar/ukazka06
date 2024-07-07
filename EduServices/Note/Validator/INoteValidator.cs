using Core.Base.Validator;
using Model.Edu.Note;
using Repository.NoteRepository;
using Services.Note.Dto;

namespace Services.Note.Validator
{
    public interface INoteValidator : IBaseValidator<NoteDbo, INoteRepository, NoteCreateDto, NoteDetailDto, NoteUpdateDto> { }
}
