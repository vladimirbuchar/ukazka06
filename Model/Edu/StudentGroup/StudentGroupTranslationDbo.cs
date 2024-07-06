using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.StudentGroup
{
    [Table("Edu_StudentGroupTranslation")]
    public class StudentGroupTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        public virtual StudentGroupDbo StudentGroup { get; set; }
        public virtual Guid StudentGroupId { get; set; }
    }
}
