using Core.Base.Dto;

namespace UserService.Notification.NotificationList.Dto
{
    public class NotificationListDto : ListDto
    {
        public string? NotificationIdentificator { get; set; }
        public Guid ObjectId { get; set; }
        public required Dictionary<string, string> Data { get; set; }
        public bool IsNew { get; set; }
        public DateTime AddDate { get; set; }
    }
}
