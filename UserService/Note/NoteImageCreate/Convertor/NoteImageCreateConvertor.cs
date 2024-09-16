using Model.Edu.Note;
using UserService.Note.NoteImageCreate.Dto;

namespace UserService.Note.NoteImageCreate.Convertor
{
    public class NoteImageCreateConvertor : INoteImageCreateConvertor
    {
        public Task<NoteDbo> ConvertToBussinessEntity(NoteImageCreateDto create, string culture)
        {
            return Task.FromResult(
                new NoteDbo()
                {
                    CourseId = create.CourseId,
                    NoteTypeId = create.NoteTypeId,
                    Text = create.Text,
                    NoteName = create.NoteName,
                    FileName = create.FileName
                }
            );
        }
    }
}
