using Core.Base.Validator;
using EduRepository.NoteRepository;
using EduServices.Note.Dto;
using Model.Tables.Edu.Note;

namespace EduServices.Note.Validator
{
    public interface INoteValidator : IBaseValidator<NoteDbo, INoteRepository, NoteCreateDto, NoteDetailDto, NoteUpdateDto> { }
}
