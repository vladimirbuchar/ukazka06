using Model.CodeBook;
using Model.Edu.Course;
using Model.Edu.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Note
{
    [Table("Edu_Note")]
    public class NoteDbo : TableModel
    {
        [Column("NoteName")]
        public string NoteName { get; set; }

        [Column("FileName")]
        public Guid FileName { get; set; }

        [Column("Text")]
        public string Text { get; set; }
        public virtual CourseDbo Course { get; set; }
        public virtual Guid CourseId { get; set; }
        public virtual NoteTypeDbo NoteType { get; set; }
        public virtual Guid NoteTypeId { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
