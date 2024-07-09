using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.Notification;
using Services.Notification.Dto;

namespace Services.Notification.Convertor
{
    public interface INotificationConvertor : IBaseConvertor
    {
        List<MyNotificationListDto> ConvertToWebModel(List<NotificationDbo> getMyNotifications);
    }
}
