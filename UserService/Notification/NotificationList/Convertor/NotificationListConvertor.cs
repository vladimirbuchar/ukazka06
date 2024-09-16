using Core.Base.Convertor;
using Model.Edu.Notification;
using UserService.Notification.NotificationList.Dto;

namespace UserService.Notification.NotificationList.Convertor
{
    public class NotificationListConvertor : IBaseListConvertor<NotificationDbo, NotificationListDto>, INotificationListConvertor
    {
        public Task<List<NotificationListDto>> ConvertToWebModel(List<NotificationDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new NotificationListDto()
                {
                    Id = item.Id,
                    NotificationIdentificator = item.SystemIdentificator,
                    ObjectId = item.OrganizationId.Value,
                    Data = item.Data,
                    AddDate = item.AddDate,
                    IsNew = item.IsNew
                })
                    .ToList()
            );
        }
    }
}
