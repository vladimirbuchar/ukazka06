using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.StudentGroup;

namespace Model.Tables.Link
{
    [Table("Link_StudentInGroup")]
    public class StudentInGroupDbo : TableModel
    {
        public virtual UserInOrganizationDbo UserInOrganization { get; set; }
        public virtual Guid UserInOrganizationId { get; set; }
        public virtual StudentGroupDbo StudentGroup { get; set; }
        public virtual Guid StudentGroupId { get; set; }
    }
}
