using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.CourseTerm;
using Model.Edu.User;

namespace Model.Edu.Chat
{
    [Table("Edu_Chat")]
    public class ChatDbo : TableModel
    {
        [Column("Text")]
        public virtual string Text { get; set; }

        [Column("Date")]
        public virtual DateTime Date { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
    }
}
