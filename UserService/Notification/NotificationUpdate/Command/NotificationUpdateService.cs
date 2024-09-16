using Core.Base.Command.Update;
using Model.Edu.Notification;
using Repository.Notification;
using UserService.Notification.NotificationUpdate.Convertor;
using UserService.Notification.NotificationUpdate.Dto;
using UserService.Notification.NotificationUpdate.Validator;

namespace UserService.Notification.NotificationUpdate.Command
{
    public class NotificationUpdateService
        : BaseUpdateCommand<
            NotificationDbo,
            INotificationRepository,
            NotificationUpdateDto,
            INotificationUpdateConvertor,
            INotificationUpdateValidator
        >,
            INotificationUpdateService
    {
        public NotificationUpdateService(
            INotificationRepository repository,
            INotificationUpdateConvertor convertor,
            INotificationUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
