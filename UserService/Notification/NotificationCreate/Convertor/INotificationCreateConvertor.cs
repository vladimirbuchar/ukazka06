using Core.Base.Convertor;
using Model.Edu.Notification;
using UserService.Notification.NotificationCreate.Dto;

namespace UserService.Notification.NotificationCreate.Convertor
{
    public interface INotificationCreateConvertor : IBaseCreateConvertor<NotificationDbo, NotificationCreateDto> { }
}
