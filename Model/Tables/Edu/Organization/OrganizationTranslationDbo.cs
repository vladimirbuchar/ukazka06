using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Organization
{
    [Table("Edu_OrganizationTranslation")]
    public class OrganizationTranslationDbo : TranslationTableModel
    {
        [Column("Description")]
        public virtual string Description { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
    }
}
