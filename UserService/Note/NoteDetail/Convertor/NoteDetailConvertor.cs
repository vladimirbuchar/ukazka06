using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.Edu.Note;
using UserService.Note.NoteDetail.Dto;

namespace UserService.Note.NoteDetail.Convertor
{
    public class NoteDetailConvertor : INoteDetailConvertor
    {
        private readonly string _fileRepositoryPath;
        public NoteDetailConvertor(IConfiguration configuration)
        {
            _fileRepositoryPath = string.Format(
                "{0}{1}/",
                configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                ConfigValue.NOTE
            );
        }
        public Task<NoteDetailDto> ConvertToWebModel(NoteDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new NoteDetailDto()
                {
                    Id = detail.Id,
                    NoteName = detail.NoteName,
                    NoteType = detail.NoteType.SystemIdentificator,
                    Text = detail.Text,
                    FilePath = string.Format("{0}{1}.png", _fileRepositoryPath, detail.FileName)
                }
            );
        }
    }
}
