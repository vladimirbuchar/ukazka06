using Model.Edu.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.UserCertificate
{
    [Table("Edu_UserCertificate")]
    public class UserCertificateDbo : TableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("FileName")]
        public virtual string FileName { get; set; }

        [Column("ActiveFrom")]
        public virtual DateTime ActiveFrom { get; set; }

        [Column("ValidTo")]
        public virtual DateTime ValidTo { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
