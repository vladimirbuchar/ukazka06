using Model.CodeBook;
using Model.Edu.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.SendMessage
{
    [Table("Edu_SendMessage")]
    public class MessageDbo : TableModel
    {
        [Column("Reply")]
        public virtual string Reply { get; set; }
        public virtual SendMessageTypeDbo SendMessageType { get; set; }
        public virtual Guid SendMessageTypeId { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual ICollection<SendMessageTranslationDbo> SendMessageTranslations { get; set; }
    }
}
