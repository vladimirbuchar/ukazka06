using Core.Base.Validator;
using Model.Edu.Notification;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserService.Notification.NotificationUpdate.Validator
{
    public interface INotificationUpdateValidator : IBaseUpdateValidator<NotificationDbo, NotificationUpdateDto> { }
}
