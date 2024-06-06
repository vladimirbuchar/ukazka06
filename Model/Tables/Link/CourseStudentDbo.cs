using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.AttendanceStudent;
using Model.Tables.Edu.CourseTerm;

namespace Model.Tables.Link
{
    [Table("Link_CourseStudent")]
    public class CourseStudentDbo : TableModel
    {
        public virtual bool CourseFinish { get; set; }
        public virtual UserInOrganizationDbo UserInOrganization { get; set; }
        public virtual Guid UserInOrganizationId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual IEnumerable<StudentAttendanceDbo> AttendanceStudents { get; set; }
    }
}
