using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.SendEmail
{
    [Table("Edu_SendEmail")]
    public class SendEmailDbo : TableModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string PlainTextBody { get; set; }
        public bool IsHtml { get; set; } = true;
        public string EmailFrom { get; set; }
        public string EmailFromName { get; set; }
        public string EmailTo { get; set; }
        public string EmailToName { get; set; }
        public bool IsSended { get; set; } = false;
        public string Reply { get; set; }
        public virtual Guid? OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual ICollection<SendEmailAttachmentDbo> SendEmailAttachments { get; set; }
    }
}
