﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.SendEmail;

namespace Model.Edu.SendEmailAttachment
{
    [Table("Edu_SendEmailAttachment")]
    public class SendEmailAttachmentDbo : TableModel
    {
        public virtual Guid SendEmailId { get; set; }
        public virtual SendEmailDbo SendEmail { get; set; }

        [Column("Attachment")]
        public virtual string Attachment { get; set; }
    }
}
