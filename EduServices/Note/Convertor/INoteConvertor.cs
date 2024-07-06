using Core.Base.Convertor;
using EduServices.Note.Dto;
using Model.Edu.Note;

namespace EduServices.Note.Convertor
{
    public interface INoteConvertor : IBaseConvertor<NoteDbo, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto> { }
}
