using Model.Edu.Note;
using UserService.Note.NoteList.Dto;

namespace UserService.Note.NoteList.Convertor
{
    public class NoteListConvertor : INoteListConvertor
    {
        public Task<List<NoteListDto>> ConvertToWebModel(List<NoteDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list
                    .Select(x => new NoteListDto()
                    {
                        Id = x.Id,
                        NoteName = x.NoteName,
                        NoteType = x.NoteType.SystemIdentificator,
                    })
                    .ToList()
            );
        }
    }
}
