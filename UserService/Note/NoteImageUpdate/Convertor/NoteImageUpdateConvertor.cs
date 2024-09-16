using Model.Edu.Note;
using UserService.Note.NoteImageUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Convertor
{
    public class NoteImageUpdateConvertor : INoteImageUpdateConvertor
    {
        public Task<NoteDbo> ConvertToBussinessEntity(NoteImageUpdateDto update, NoteDbo entity, string culture)
        {
            return Task.FromResult(
               new NoteDbo()
               {
                   Text = update.Text,
                   NoteName = update.NoteName,
                   FileName = update.FileName
               }
           );
        }
    }
}
