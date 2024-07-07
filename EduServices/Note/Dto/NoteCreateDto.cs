using Core.Base.Dto;
using System;

namespace Services.Note.Dto
{
    public class NoteCreateDto : CreateDto
    {
        public string Text { get; set; }
        public Guid NoteTypeId { get; set; }
        public Guid CourseId { get; set; }
        public string NoteName { get; set; }
        public Guid UserId { get; set; }
        public Guid FileName { get; set; }
    }

}
