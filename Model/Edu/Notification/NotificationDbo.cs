using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;
using Model.Edu.CourseTerm;
using Model.Edu.Organization;
using Model.Edu.User;

namespace Model.Edu.Notification
{
    [Table("Edu_Notification")]
    public class NotificationDbo : TableModel
    {
        public NotificationDbo()
        {
            Data = [];
        }

        [Column("IsNew")]
        public virtual bool IsNew { get; set; } = true;

        [Column("AddDate")]
        public virtual DateTime AddDate { get; set; }
        public virtual NotificationTypeDbo NotificationType { get; set; }
        public virtual Guid? NotificationTypeId { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid? OrganizationId { get; set; }

        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid? CourseTermId { get; set; }

        [NotMapped]
        public Dictionary<string, string> Data { get; set; }
    }
}
