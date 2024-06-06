using Model.Tables.Link;
using Model.Tables.System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.OrganizationRole
{
    [Table("Edu_OrganizationRole")]
    public class OrganizationRoleDbo : TableModel
    {
        [Column("Priority")]
        public virtual int Priority { get; set; }

        public virtual ICollection<UserInOrganizationDbo> UserInOrganizations { get; set; }
        public virtual ICollection<PermissionsDbo> Permissions { get; set; }
    }
}
