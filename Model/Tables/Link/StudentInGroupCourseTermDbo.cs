using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Edu.StudentGroup;

namespace Model.Tables.Link
{
    [Table("Link_StudentInGroupCourseTerm")]
    public class StudentInGroupCourseTermDbo : TableModel
    {
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual StudentGroupDbo StudentGroup { get; set; }
        public virtual Guid StudentGroupId { get; set; }
    }
}
