using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Branch
{
    [Table("Edu_BranchTranslation")]
    public class BranchTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        [Column("Description")]
        public virtual string Description { get; set; }
        public virtual BranchDbo Branch { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
