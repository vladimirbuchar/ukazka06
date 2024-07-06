using Core.Base.Validator;
using EduRepository.NoteRepository;
using EduServices.Note.Dto;
using Model.Edu.Note;

namespace EduServices.Note.Validator
{
    public interface INoteValidator : IBaseValidator<NoteDbo, INoteRepository, NoteCreateDto, NoteDetailDto, NoteUpdateDto> { }
}
