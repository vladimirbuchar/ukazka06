﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Link;
using Model.System;

namespace Model.Edu.OrganizationRole
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
