using System;
using Core.Base.Request;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.Note;
using Services.Note.Dto;

namespace Services.Note.Service
{
    public interface INoteService : IBaseService<NoteDbo, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto, FilterRequest>
    {
        Result<NoteDetailDto> SaveTableAsNote(NoteCreateTableDto saveTableAsNoteDto, Guid userId, string culture);
        Result<NoteDetailDto> SaveFile(NoteCreateImageDto saveImageNoteDto, Guid userId, string culture);
        Result<NoteDetailDto> UpdateNoteImage(NoteUpdateImageDto updateNoteImageDto, Guid userId, string culture);
    }
}
