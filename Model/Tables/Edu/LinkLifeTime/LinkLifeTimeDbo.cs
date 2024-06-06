using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.User;

namespace Model.Tables.Edu.LinkLifeTime
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
