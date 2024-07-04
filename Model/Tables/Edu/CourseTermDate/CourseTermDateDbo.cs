using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.AttendanceStudent;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Link;

namespace Model.Tables.Edu.CourseTermDate
{
    [Table("Edu_CourseTermDate")]
    public class CourseTermDateDbo : TableModel
    {
        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("DayOfWeek")]
        public virtual string DayOfWeek { get; set; }

        [Column("TimeFrom")]
        public virtual TimeTableDbo TimeFrom { get; set; }
        public virtual Guid TimeFromId { get; set; }

        [Column("TimeTo")]
        public virtual TimeTableDbo TimeTo { get; set; }
        public virtual Guid TimeToId { get; set; }
        public virtual ClassRoomDbo ClassRoom { get; set; }
        public virtual Guid ClassRoomId { get; set; }
        public virtual UserInOrganizationDbo UserInOrganization { get; set; }
        public virtual Guid UserInOrganizationId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual IEnumerable<AttendanceStudentDbo> AttendanceStudents { get; set; }
    }
}
