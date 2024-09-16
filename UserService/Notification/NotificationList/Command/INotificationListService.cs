using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.Notification;
using UserService.Notification.NotificationList.Dto;

namespace UserService.Notification.NotificationList.Command
{
    public interface INotificationListService : IBaseListCommand<NotificationDbo, NotificationListDto, RequestFilter> { }
}
