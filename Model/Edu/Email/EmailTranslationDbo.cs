using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Email
{
    [Table("Edu_EmailTranslation")]
    public class EmailTranslationDbo : TranslationTableModel
    {
        [Column("Subject")]
        public virtual string Subject { get; set; }

        [Column("EmailBodyHtml")]
        public virtual string EmailBodyHtml { get; set; }

        [Column("EmailBodyPlainText")]
        public virtual string EmailBodyPlainText { get; set; }
        public virtual EmailDbo EmailDbo { get; set; }
        public virtual Guid EmailId { get; set; }

    }
}
