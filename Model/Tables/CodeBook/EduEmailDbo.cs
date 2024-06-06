using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    [Table("Cb_Email")]
    public class EduEmailDbo : CodeBook
    {
        [Column("Subject")]
        public virtual string Subject { get; set; }

        [Column("EmailBodyHtml")]
        public virtual string EmailBodyHtml { get; set; }

        [Column("EmailBodyPlainText")]
        public virtual string EmailBodyPlainText { get; set; }

        [Column("IsHtml")]
        public virtual bool IsHtml { get; set; } = false;

        [Column("From")]
        public virtual string From { get; set; }
    }
}
