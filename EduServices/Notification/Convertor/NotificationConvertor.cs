using System.Collections.Generic;
using System.Linq;
using EduServices.Notification.Dto;
using Model.Edu.Notification;

namespace EduServices.Notification.Convertor
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
