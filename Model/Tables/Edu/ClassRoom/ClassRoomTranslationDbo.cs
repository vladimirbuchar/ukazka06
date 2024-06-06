using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.ClassRoom
{
    [Table("Edu_ClassRoomTranslation")]
    public class ClassRoomTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        public virtual ClassRoomDbo ClassRoom { get; set; }
        public virtual Guid ClassRoomId { get; set; }
    }
}
