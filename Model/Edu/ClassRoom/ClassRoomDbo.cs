using Model.Edu.Branch;
using Model.Edu.CourseTermDate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.ClassRoom
{
    [Table("Edu_ClassRoom")]
    public class ClassRoomDbo : TableModel
    {
        [Column("Floor")]
        public virtual int Floor { get; set; }

        [Column("MaxCapacity")]
        public virtual int MaxCapacity { get; set; }

        [Column("IsOnline")]
        public virtual bool IsOnline { get; set; }
        public virtual BranchDbo Branch { get; set; }
        public virtual Guid BranchId { get; set; }
        public virtual ICollection<ClassRoomTranslationDbo> ClassRoomTranslations { get; set; }
        public virtual ICollection<CourseTermDateDbo> CourseTermDates { get; set; }
    }
}
