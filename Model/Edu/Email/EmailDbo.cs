using Model.CodeBook;
using Model.Edu.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Email
{
    [Table("Edu_Email")]
    public class EmailDbo : TableModel
    {
        [Column("IsHtml")]
        public virtual bool IsHtml { get; set; } = false;

        [Column("From")]
        public virtual string From { get; set; }
        public virtual EmailTypeDbo EmailType { get; set; }
        public virtual Guid EmailTypeId { get; set; }
        public ICollection<EmailTranslationDbo> EmailTranslations { get; set; }
        public OrganizationDbo Organization { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
