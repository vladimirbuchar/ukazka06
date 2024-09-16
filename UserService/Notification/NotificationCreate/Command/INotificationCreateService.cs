using Core.Base.Command.Create;
using Model.Edu.Notification;
using UserService.Notification.NotificationCreate.Dto;

namespace UserService.Notification.NotificationCreate.Command
{
    public interface INotificationCreateService : IBaseCreateCommand<NotificationDbo, NotificationCreateDto> { }
}
