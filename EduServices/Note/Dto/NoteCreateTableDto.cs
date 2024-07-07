using Core.Base.Dto;
using System;

namespace Services.Note.Dto
{
    public class NoteCreateTableDto : ListDto
    {
        public string Img { get; set; }
        public Guid CourseLessonItem { get; set; }
    }
}
