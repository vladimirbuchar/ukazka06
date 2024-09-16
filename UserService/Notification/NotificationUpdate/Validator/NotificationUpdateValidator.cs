using Core.Base.Validator;
using Model.Edu.Notification;
using Repository.Notification;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserService.Notification.NotificationUpdate.Validator
{
    public class NotificationUpdateValidator
        : BaseUpdateValidator<NotificationDbo, INotificationRepository, NotificationUpdateDto>,
            INotificationUpdateValidator
    {
        public NotificationUpdateValidator(INotificationRepository repository)
            : base(repository) { }
    }
}
