using Core.Base.Dto;
using System;
using System.Collections.Generic;

namespace Services.Notification.Dto
{
    public class MyNotificationListDto : ListDto
    {
        public string NotificationIdentificator { get; set; }
        public Guid ObjectId { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public bool IsNew { get; set; }
        public DateTime AddDate { get; set; }
    }
}
