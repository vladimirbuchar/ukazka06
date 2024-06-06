using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.Certificate
{
    [Table("Edu_Certificate")]
    public class CertificateDbo : TableModel
    {
        [Column("CertificateValidTo")]
        public virtual int CertificateValidTo { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual ICollection<CertificateTranslationDbo> CertificateTranslations { get; set; }
    }
}
