using Core.Base.Convertor;
using Model.Edu.Notification;
using Services.Notification.Dto;
using System.Collections.Generic;

namespace Services.Notification.Convertor
{
    public interface INotificationConvertor : IBaseConvertor
    {
        HashSet<MyNotificationListDto> ConvertToWebModel(HashSet<NotificationDbo> getMyNotifications);
    }
}
