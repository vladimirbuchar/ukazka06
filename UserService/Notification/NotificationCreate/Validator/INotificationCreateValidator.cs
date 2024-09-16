using Core.Base.Validator;
using Model.Edu.Notification;
using UserService.Notification.NotificationCreate.Dto;

namespace UserService.Notification.NotificationCreate.Validator
{
    public interface INotificationCreateValidator : IBaseCreateValidator<NotificationDbo, NotificationCreateDto> { }
}
