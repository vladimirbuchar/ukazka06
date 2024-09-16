using Model.Edu.Notification;
using UserService.Notification.NotificationCreate.Dto;

namespace UserService.Notification.NotificationCreate.Convertor
{
    public class NotificationCreateConvertor : INotificationCreateConvertor
    {
        public Task<NotificationDbo> ConvertToBussinessEntity(NotificationCreateDto create, string culture)
        {
            return Task.FromResult(
                new NotificationDbo()
                {
                    AddDate = DateTime.Now,
                    IsNew = true,
                    NotificationTypeId = create.NotificationTypeId,
                    OrganizationId = create.OrganizationId,
                    UserId = create.UserId,
                }
            );
        }
    }
}
