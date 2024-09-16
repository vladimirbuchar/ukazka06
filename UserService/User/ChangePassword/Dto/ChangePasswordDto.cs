using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace UserService.User.ChangePassword.Dto
{
    public class ChangePasswordDto : UpdateDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }

        public string? OldUserPassword { get; set; }
        public string? NewUserPassword { get; set; }
        public string? NewUserPassword2 { get; set; }
    }
}
