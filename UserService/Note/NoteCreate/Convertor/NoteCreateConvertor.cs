using Model.Edu.Note;
using UserService.Note.NoteCreate.Dto;

namespace UserService.Note.NoteCreate.Convertor
{
    public class NoteCreateConvertor : INoteCreateConvertor
    {
        public Task<NoteDbo> ConvertToBussinessEntity(NoteCreateDto create, string culture)
        {
            return Task.FromResult(
                new NoteDbo()
                {
                    CourseId = create.CourseId,
                    NoteTypeId = create.NoteTypeId,
                    Text = create.Text,
                    NoteName = create.NoteName
                }
            );
        }
    }
}
