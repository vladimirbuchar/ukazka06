using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Organization;
using Model.Tables.Edu.OrganizationRole;
using Model.Tables.Edu.User;

namespace Model.Tables.Link
{
    [Table("Link_UserInOrganization")]
    public class UserInOrganizationDbo : TableModel
    {
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual OrganizationRoleDbo OrganizationRole { get; set; }
        public virtual Guid OrganizationRoleId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual IEnumerable<CourseLectorDbo> CourseLectors { get; set; }
        public virtual IEnumerable<CourseStudentDbo> CourseStudents { get; set; }
        public virtual IEnumerable<StudentInGroupDbo> StudentInGroups { get; set; }
    }
}
