using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public abstract class TableModel
    {
        [Key]
        [Column("Id")]
        public virtual Guid Id { get; set; }

        [Column("IsDeleted")]
        public virtual bool IsDeleted { get; set; } = false;

        [Column("IsSystemObject")]
        public virtual bool IsSystemObject { get; set; } = false;

        [Column("SystemIdentificator")]
        public virtual string SystemIdentificator { get; set; }

        [Column("IsActive")]
        public virtual bool? IsActive { get; set; }

        [Column("DeletedBy")]
        public virtual Guid? DeletedBy { get; set; }

        [Column("DeletedTime")]
        public virtual DateTime? DeletedTime { get; set; }

        [Column("UpdatedBy")]
        public virtual Guid? UpdatedBy { get; set; }

        [Column("UpdatedTime")]
        public virtual DateTime? UpdatedTime { get; set; }

        [Column("CreatedBy")]
        public virtual Guid? CreatedBy { get; set; }

        [Column("CreatedTime")]
        public virtual DateTime? CreatedTime { get; set; }
    }
}
