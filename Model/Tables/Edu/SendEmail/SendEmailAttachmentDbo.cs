using System;

namespace Model.Tables.Edu.SendEmail
{
    public class SendEmailAttachmentDbo : TableModel
    {
        public virtual Guid SendEmailId { get; set; }
        public virtual SendEmailDbo SendEmail { get; set; }
        public virtual string Attachment { get; set; }
    }
}
