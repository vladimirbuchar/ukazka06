using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.Message
{
    [Table("Edu_SendMessageTranslation")]
    public class MessageTemplateTranslationDbo : TranslationTableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }

        [Column("Subject")]
        public virtual string Subject { get; set; }
        public virtual MessageTemplateDbo SendMessage { get; set; }
        public virtual Guid SendMessageId { get; set; }
    }
}
