using Core.Base.Convertor;
using Model.Edu.Notification;
using UserService.Notification.NotificationList.Dto;

namespace UserService.Notification.NotificationList.Convertor
{
    public interface INotificationListConvertor : IBaseListConvertor<NotificationDbo, NotificationListDto> { }
}
