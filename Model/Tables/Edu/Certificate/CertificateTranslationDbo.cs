using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Certificate
{
    [Table("Edu_CertificateTranslation")]
    public class CertificateTranslationDbo : TranslationTableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }

        [Column("Html")]
        public virtual string Html { get; set; }
        public virtual CertificateDbo Certificate { get; set; }
        public virtual Guid CertificateId { get; set; }
    }
}
