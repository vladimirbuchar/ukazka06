using Core.Base.Convertor;
using Model.Edu.Notification;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserService.Notification.NotificationUpdate.Convertor
{
    public interface INotificationUpdateConvertor : IBaseUpdateConvertor<NotificationDbo, NotificationUpdateDto> { }
}
