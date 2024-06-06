using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using EduRepository.NoteRepository;
using EduServices.Note.Convertor;
using EduServices.Note.Dto;
using EduServices.Note.Validator;
using EduServices.SystemService.FileUpload;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Note;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Note.Service
{
    public class NoteService(
        INoteRepository noteRepository,
        INoteConvertor noteConvertor,
        IFileUploadService fileUploadService,
        ICodeBookRepository<NoteTypeDbo> codeBookService,
        INoteValidator validator
    ) : BaseService<INoteRepository, NoteDbo, INoteConvertor, INoteValidator, NoteCreateDto, NoteListDto, NoteDetailDto, NoteUpdateDto>(noteRepository, noteConvertor, validator), INoteService
    {
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly HashSet<NoteTypeDbo> _noteType = codeBookService.GetCodeBookItems();

        public Result<NoteDetailDto> SaveTableAsNote(NoteCreateTableDto saveTableAsNoteDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveTableAsNoteDto.Img, "note");
            NoteCreateDto addNote =
                new()
                {
                    CourseId = saveTableAsNoteDto.CourseLessonItem,
                    FileName = fileName,
                    NoteName = DateTime.Now.ToString(),
                    NoteTypeId = _noteType.FirstOrDefault(x => x.SystemIdentificator == NoteType.NOTE_TYPE_DRAW).Id,
                    Text = "",
                    UserId = userId
                };
            return AddObject(addNote, userId, culture);
        }

        public Result<NoteDetailDto> UpdateNoteImage(NoteUpdateImageDto updateNoteImageDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(updateNoteImageDto.Img, "note");
            updateNoteImageDto.FileName = fileName;
            return UpdateObject(updateNoteImageDto, userId, culture);
        }

        public Result<NoteDetailDto> SaveFile(NoteCreateImageDto saveImageNoteDto, Guid userId, string culture)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveImageNoteDto.Img, "note");
            saveImageNoteDto.UserId = userId;
            saveImageNoteDto.FileName = fileName;
            return AddObject(saveImageNoteDto, userId, culture);
        }
    }
}
