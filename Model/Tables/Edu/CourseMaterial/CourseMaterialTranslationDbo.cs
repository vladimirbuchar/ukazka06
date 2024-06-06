using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.CourseMaterial
{
    [Table("Edu_CourseMaterialTranslation")]
    public class CourseMaterialTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Description")]
        public virtual string Description { get; set; }
        public virtual CourseMaterialDbo CourseMaterial { get; set; }
        public virtual Guid CourseMaterialId { get; set; }
    }
}
