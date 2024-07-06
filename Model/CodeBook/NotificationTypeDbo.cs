using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Notification;

namespace Model.CodeBook
{
    [Table("Cb_NotificationType")]
    public class NotificationTypeDbo : CodeBook
    {
        public virtual IEnumerable<NotificationDbo> Notifications { get; set; }
    }
}
