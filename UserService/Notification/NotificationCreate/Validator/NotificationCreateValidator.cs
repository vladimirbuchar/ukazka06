using Core.Base.Validator;
using Model.Edu.Notification;
using Repository.Notification;
using UserService.Notification.NotificationCreate.Dto;

namespace UserService.Notification.NotificationCreate.Validator
{
    public class NotificationCreateValidator
        : BaseCreateValidator<NotificationDbo, INotificationRepository, NotificationCreateDto>,
            INotificationCreateValidator
    {
        public NotificationCreateValidator(INotificationRepository repository)
            : base(repository) { }
    }
}
