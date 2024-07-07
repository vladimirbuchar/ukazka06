using Model.Edu.OrganizationRole;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.OrganizationRolePermition
{
    [Table("Edu_OrganizationRolePermition")]
    public class OrganizationRolePermitionDbo : TableModel
    {
        [Column("PermitionIdentificator")]
        public virtual string PermitionIdentificator { get; set; }
        public virtual OrganizationRoleDbo OrganizationRole { get; set; }
        public virtual Guid OrganizationRoleId { get; set; }
    }
}
