using Core.Base.Convertor;
using Model.Edu.Note;
using UserService.Note.NoteDetail.Dto;

namespace UserService.Note.NoteDetail.Convertor
{
    public interface INoteDetailConvertor : IBaseDetailConvertor<NoteDbo, NoteDetailDto>
    {
    }
}