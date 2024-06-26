﻿using Core.Constants;
using EduServices.Note.Dto;
using Microsoft.Extensions.Configuration;
using Model.Tables.Edu.Note;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Note.Convertor
{
    public class NoteConvertor(IConfiguration configuration) : INoteConvertor
    {
        private readonly string _fileRepositoryPath = string.Format("{0}{1}/", configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, ConfigValue.NOTE);

        public NoteDbo ConvertToBussinessEntity(NoteCreateDto addNoteDto, string culture)
        {
            return new NoteDbo()
            {
                CourseId = addNoteDto.CourseId,
                NoteTypeId = addNoteDto.NoteTypeId,
                Text = addNoteDto.Text,
                NoteName = addNoteDto.NoteName
            };
        }

        public NoteDbo ConvertToBussinessEntity(NoteUpdateDto updateNoteDto, NoteDbo entity, string culture)
        {
            entity.Text = updateNoteDto.Text;
            entity.NoteName = updateNoteDto.NoteName;
            return entity;
        }

        public HashSet<NoteListDto> ConvertToWebModel(HashSet<NoteDbo> getMyNotes, string culture)
        {
            return getMyNotes
                .Select(x => new NoteListDto()
                {
                    Id = x.Id,
                    NoteName = x.NoteName,
                    NoteType = x.NoteType.SystemIdentificator,
                })
                .ToHashSet();
        }

        public NoteDetailDto ConvertToWebModel(NoteDbo getNoteDetail, string culture)
        {
            return new NoteDetailDto()
            {
                Id = getNoteDetail.Id,
                NoteName = getNoteDetail.NoteName,
                NoteType = getNoteDetail.NoteType.SystemIdentificator,
                Text = getNoteDetail.Text,
                FilePath = string.Format("{0}{1}.png", _fileRepositoryPath, getNoteDetail.FileName)
            };
        }
    }
}
