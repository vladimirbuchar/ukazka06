using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.AttendanceStudent;
using Model.Edu.CourseTerm;

namespace Model.Link
{
    [Table("Link_CourseStudent")]
    public class CourseStudentDbo : TableModel
    {
        [Column("CourseFinish")]
        public virtual bool CourseFinish { get; set; }
        public virtual UserInOrganizationDbo UserInOrganization { get; set; }
        public virtual Guid UserInOrganizationId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual IEnumerable<AttendanceStudentDbo> AttendanceStudents { get; set; }
    }
}
