using UserService.Note.NoteUpdate.Dto;

namespace UserService.Note.NoteImageUpdate.Dto
{
    public class NoteImageUpdateDto : NoteUpdateDto
    {
        public string? Img { get; set; }
        public Guid FileName { get; set; }
    }
}
