using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.SendMessage
{
    [Table("Edu_SendMessageTranslation")]
    public class SendMessageTranslationDbo : TranslationTableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }

        [Column("Subject")]
        public virtual string Subject { get; set; }
        public virtual SendMessageDbo SendMessage { get; set; }
        public virtual Guid SendMessageId { get; set; }
    }
}
