using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Notification;

namespace Model.Tables.CodeBook
{
    [Table("Cb_NotificationType")]
    public class NotificationTypeDbo : CodeBook
    {
        public virtual IEnumerable<NotificationDbo> Notifications { get; set; }
    }
}
