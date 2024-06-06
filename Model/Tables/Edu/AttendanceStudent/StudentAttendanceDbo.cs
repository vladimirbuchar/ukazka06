using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Edu.CourseTermDate;
using Model.Tables.Link;

namespace Model.Tables.Edu.AttendanceStudent
{
    [Table("Edu_AttendanceStudent")]
    public class StudentAttendanceDbo : TableModel
    {
        public virtual CourseTermDateDbo CourseTermDate { get; set; }
        public virtual Guid CourseTermDateId { get; set; }
        public virtual CourseStudentDbo CourseStudent { get; set; }
        public virtual Guid CourseStudentId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
    }
}
