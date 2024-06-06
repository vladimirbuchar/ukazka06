using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.User;

namespace Model.Tables.Edu.UserRole
{
    [Table("Edu_UserRole")]
    public class UserRoleDbo : TableModel
    {
        public virtual IEnumerable<UserDbo> Users { get; set; }
    }
}
