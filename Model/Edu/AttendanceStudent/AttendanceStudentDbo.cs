using Model.Edu.CourseTerm;
using Model.Edu.CourseTermDate;
using Model.Link;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.AttendanceStudent
{
    [Table("Edu_AttendanceStudent")]
    public class AttendanceStudentDbo : TableModel
    {
        public virtual CourseTermDateDbo CourseTermDate { get; set; }
        public virtual Guid CourseTermDateId { get; set; }
        public virtual CourseStudentDbo CourseStudent { get; set; }
        public virtual Guid CourseStudentId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
    }
}
