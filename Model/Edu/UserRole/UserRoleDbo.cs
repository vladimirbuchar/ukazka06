using Model.Edu.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.UserRole
{
    [Table("Edu_UserRole")]
    public class UserRoleDbo : TableModel
    {
        public virtual IEnumerable<UserDbo> Users { get; set; }
    }
}
