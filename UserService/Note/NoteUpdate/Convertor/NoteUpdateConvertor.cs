using Model.Edu.Note;
using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteUpdate.Convertor
{
    public class NoteUpdateConvertor : INoteUpdateConvertor
    {
        public Task<NoteDbo> ConvertToBussinessEntity(NoteUpdateDto update, NoteDbo entity, string culture)
        {
            entity.Text = update.Text;
            entity.NoteName = update.NoteName;
            return Task.FromResult(entity);
        }
    }
}
