using Core.Base.Service;
using Core.DataTypes;
using EduServices.Note.Dto;
using Model.Edu.Note;
using System;

namespace EduServices.Note.Service
{
    public interface INoteService : IBaseService<NoteDbo, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto>
    {
        Result<NoteDetailDto> SaveTableAsNote(NoteCreateTableDto saveTableAsNoteDto, Guid userId, string culture);
        Result<NoteDetailDto> SaveFile(NoteCreateImageDto saveImageNoteDto, Guid userId, string culture);
        Result<NoteDetailDto> UpdateNoteImage(NoteUpdateImageDto updateNoteImageDto, Guid userId, string culture);
    }
}
