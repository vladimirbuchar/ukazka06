using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.Edu.Note;
using Services.Note.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Note.Convertor
{
    public class NoteConvertor(IConfiguration configuration) : INoteConvertor
    {
        private readonly string _fileRepositoryPath = string.Format(
            "{0}{1}/",
            configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
            ConfigValue.NOTE
        );

        public Task<NoteDbo> ConvertToBussinessEntity(NoteCreateDto addNoteDto, string culture)
        {
            return Task.FromResult(new NoteDbo()
            {
                CourseId = addNoteDto.CourseId,
                NoteTypeId = addNoteDto.NoteTypeId,
                Text = addNoteDto.Text,
                NoteName = addNoteDto.NoteName
            });
        }

        public Task<NoteDbo> ConvertToBussinessEntity(NoteUpdateDto updateNoteDto, NoteDbo entity, string culture)
        {
            entity.Text = updateNoteDto.Text;
            entity.NoteName = updateNoteDto.NoteName;
            return Task.FromResult(entity);
        }

        public Task<List<NoteListDto>> ConvertToWebModel(List<NoteDbo> getMyNotes, string culture)
        {
            return Task.FromResult(getMyNotes
                .Select(x => new NoteListDto()
                {
                    Id = x.Id,
                    NoteName = x.NoteName,
                    NoteType = x.NoteType.SystemIdentificator,
                })
                .ToList());
        }

        public Task<NoteDetailDto> ConvertToWebModel(NoteDbo getNoteDetail, string culture)
        {
            return Task.FromResult(new NoteDetailDto()
            {
                Id = getNoteDetail.Id,
                NoteName = getNoteDetail.NoteName,
                NoteType = getNoteDetail.NoteType.SystemIdentificator,
                Text = getNoteDetail.Text,
                FilePath = string.Format("{0}{1}.png", _fileRepositoryPath, getNoteDetail.FileName)
            });
        }
    }
}
