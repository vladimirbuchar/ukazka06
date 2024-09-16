using Model.Edu.StudentGroup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Link
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
