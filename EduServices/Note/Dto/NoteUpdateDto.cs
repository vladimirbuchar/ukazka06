using Core.Base.Dto;

namespace Services.Note.Dto
{
    public class NoteUpdateDto : UpdateDto
    {
        public string Text { get; set; }
        public string NoteName { get; set; }
    }
}
