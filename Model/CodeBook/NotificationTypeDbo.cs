using Model.Edu.Notification;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_NotificationType")]
    public class NotificationTypeDbo : CodeBook
    {
        public virtual IEnumerable<NotificationDbo> Notifications { get; set; }
    }
}
