using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.User;

namespace Model.Tables.System
{
    [Table("System_ObjectHistory")]
    public class ObjectHistoryDbo : TableModel
    {
        [Column("ObjectId")]
        public virtual Guid ObjectId { get; set; }

        [Column("OldValue")]
        public virtual string OldValue { get; set; }

        [Column("ObjectType")]
        public virtual string ObjectType { get; set; }

        [Column("EventType")]
        public virtual string EventType { get; set; }

        [Column("ActionTime")]
        public virtual DateTime ActionTime { get; set; }
        public virtual UserDbo User { get; set; }
    }
}
