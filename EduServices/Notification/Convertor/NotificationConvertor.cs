using Model.Edu.Notification;
using Services.Notification.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Services.Notification.Convertor
{
    public class NotificationConvertor : INotificationConvertor
    {
        public HashSet<MyNotificationListDto> ConvertToWebModel(HashSet<NotificationDbo> getMyNotifications)
        {
            return getMyNotifications
                .Select(item => new MyNotificationListDto()
                {
                    Id = item.Id,
                    NotificationIdentificator = item.SystemIdentificator,
                    ObjectId = item.OrganizationId.Value,
                    Data = item.Data,
                    AddDate = item.AddDate,
                    IsNew = item.IsNew
                })
                .ToHashSet();
        }
    }
}
