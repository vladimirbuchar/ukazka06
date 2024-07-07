using Model.Edu.Course;
using Model.Edu.CourseLessonItem;
using Model.Edu.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Link
{
    [Table("Link_CouseStudentMaterial")]
    public class CouseStudentMaterialDbo : TableModel
    {
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual CourseLessonItemDbo CourseLessonItem { get; set; }
        public virtual Guid CourseLessonItemId { get; set; }
        public virtual CourseDbo Course { get; set; }
        public virtual Guid CourseId { get; set; }
    }
}
