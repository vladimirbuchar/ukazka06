using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Branch
{
    [Table("Edu_BranchTranslation")]
    public class BranchTranslationDbo : TranslationTableModel
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual BranchDbo Branch { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
