using System;

namespace Services.Note.Dto
{
    public class NoteUpdateImageDto : NoteUpdateDto
    {
        public string Img { get; set; }
        public Guid FileName { get; set; }
    }
}
