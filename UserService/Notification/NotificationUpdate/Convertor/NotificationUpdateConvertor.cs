using Model.Edu.Notification;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserService.Notification.NotificationUpdate.Convertor
{
    public class NotificationUpdateConvertor : INotificationUpdateConvertor
    {
        public Task<NotificationDbo> ConvertToBussinessEntity(NotificationUpdateDto update, NotificationDbo entity, string culture)
        {
            entity.IsNew = update.IsNew;
            return Task.FromResult(entity);
        }
    }
}
