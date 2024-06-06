using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseLessonItem;
using Model.Tables.Edu.User;

namespace Model.Tables.Link
{
    [Table("Link_CourseBrowse")]
    public class CourseBrowseDbo : TableModel
    {
        public virtual CourseDbo Course { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseLessonItemDbo CourseLessonItem { get; set; }
        public virtual Guid CourseLessonItemId { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
