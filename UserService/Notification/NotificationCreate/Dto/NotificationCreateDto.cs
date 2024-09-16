using Core.Base.Dto;

namespace UserService.Notification.NotificationCreate.Dto
{
    public class NotificationCreateDto : CreateDto
    {
        public Guid UserId { get; set; }
        public Guid NotificationTypeId { get; set; }
        public Guid OrganizationId { get; set; }
        public string? NotificationType { get; set; }
    }
}
