using System;

namespace EduServices.Note.Dto
{
    public class NoteUpdateImageDto : NoteUpdateDto
    {
        public string Img { get; set; }
        public Guid FileName { get; set; }
    }
}
