using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Message
{
    [Table("Edu_SendMessageTranslation")]
    public class MessageTranslationDbo : TranslationTableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }

        [Column("Subject")]
        public virtual string Subject { get; set; }
        public virtual MessageDbo SendMessage { get; set; }
        public virtual Guid SendMessageId { get; set; }
    }
}
