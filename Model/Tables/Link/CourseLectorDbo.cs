using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;

namespace Model.Tables.Link
{
    [Table("Link_CourseLector")]
    public class CourseLectorDbo : TableModel
    {
        public virtual UserInOrganizationDbo UserInOrganization { get; set; }
        public virtual Guid UserInOrganizationId { get; set; }
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
    }
}
