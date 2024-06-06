using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.SendMessage
{
    [Table("Edu_SendMessage")]
    public class SendMessageDbo : TableModel
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
