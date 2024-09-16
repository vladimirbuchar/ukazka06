using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace UserService.Notification.NotificationUpdate.Dto
{
    public class NotificationUpdateDto : UpdateDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        public bool IsNew { get; set; }
    }
}
