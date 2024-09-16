using Core.Base.Dto;

namespace UserService.Note.NoteUpdate.Dto
{
    public class NoteUpdateDto : UpdateDto
    {
        public string? Text { get; set; }
        public string? NoteName { get; set; }
    }
}
