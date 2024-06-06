using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Edu.User;

namespace Model.Tables.Edu.Chat
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
