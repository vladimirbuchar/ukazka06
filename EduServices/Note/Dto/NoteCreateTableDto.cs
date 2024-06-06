using Core.Base.Dto;
using System;

namespace EduServices.Note.Dto
{
    public class NoteCreateTableDto : ListDto
    {
        public string Img { get; set; }
        public Guid CourseLessonItem { get; set; }
    }
}
