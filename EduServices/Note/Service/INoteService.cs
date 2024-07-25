using Core.Base.Filter;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.Note;
using Services.Note.Dto;
using System;
using System.Threading.Tasks;

namespace Services.Note.Service
{
   
    public interface INoteService : IBaseService<NoteDbo, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto, FilterRequest>
    {
        Task<Result> SaveTableAsNote(NoteCreateTableDto saveTableAsNoteDto, Guid userId, string culture);
        Task<Result> SaveFile(NoteCreateImageDto saveImageNoteDto, Guid userId, string culture);
        Task<Result> UpdateNoteImage(NoteUpdateImageDto updateNoteImageDto, Guid userId, string culture);
    }
}
