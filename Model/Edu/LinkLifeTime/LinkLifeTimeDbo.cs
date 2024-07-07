using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.User;

namespace Model.Edu.LinkLifeTime
{
    [Table("Edu_LinkLifeTime")]
    public class LinkLifeTimeDbo : TableModel
    {
        [Column("EndTime")]
        public virtual DateTime EndTime { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
