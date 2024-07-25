using Core.Base.Filter;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Note;
using Repository.NoteRepository;
using Services.Note.Convertor;
using Services.Note.Dto;
using Services.Note.Validator;
using Services.SystemService.FileUpload;
using System;
using System.Threading.Tasks;

namespace Services.Note.Service
{
   
    public class NoteService(
        INoteRepository noteRepository,
        INoteConvertor noteConvertor,
        IFileUploadService fileUploadService,
        ICodeBookRepository<NoteTypeDbo> codeBookRepository,
        INoteValidator validator
    )
        : BaseService<
            INoteRepository,
            NoteDbo,
            INoteConvertor,
            INoteValidator,
            NoteCreateDto,
            NoteListDto,
            NoteDetailDto,
            NoteUpdateDto,
            FilterRequest
        >(noteRepository, noteConvertor, validator),
            INoteService
    {
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly ICodeBookRepository<NoteTypeDbo> _noteType = codeBookRepository;

        public async Task<Result> SaveTableAsNote(NoteCreateTableDto saveTableAsNoteDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveTableAsNoteDto.Img, "note");
            NoteCreateDto addNote =
                new()
                {
                    CourseId = saveTableAsNoteDto.CourseLessonItem,
                    FileName = fileName,
                    NoteName = DateTime.Now.ToString(),
                    NoteTypeId = (await _noteType.GetEntity(false, x => x.SystemIdentificator == NoteType.NOTE_TYPE_DRAW)).Id,
                    Text = "",
                    UserId = userId
                };
            return await AddObject(addNote, userId, culture);
        }

        public async Task<Result> UpdateNoteImage(NoteUpdateImageDto updateNoteImageDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(updateNoteImageDto.Img, "note");
            updateNoteImageDto.FileName = fileName;
            return await UpdateObject(updateNoteImageDto, userId, culture);
        }

        public async Task<Result> SaveFile(NoteCreateImageDto saveImageNoteDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveImageNoteDto.Img, "note");
            saveImageNoteDto.UserId = userId;
            saveImageNoteDto.FileName = fileName;
            return await AddObject(saveImageNoteDto, userId, culture);
        }
    }
}
