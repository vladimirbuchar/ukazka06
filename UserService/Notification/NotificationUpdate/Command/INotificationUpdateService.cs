using Core.Base.Command.Update;
using Model.Edu.Notification;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserService.Notification.NotificationUpdate.Command
{
    public interface INotificationUpdateService : IBaseUpdateCommand<NotificationDbo, NotificationUpdateDto> { }
}
