using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.Notification.Dto;
using Model.Tables.Edu.Notification;

namespace EduServices.Notification.Convertor
{
    public interface INotificationConvertor : IBaseConvertor
    {
        HashSet<MyNotificationListDto> ConvertToWebModel(HashSet<NotificationDbo> getMyNotifications);
    }
}
