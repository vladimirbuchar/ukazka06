using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace UserService.User.SetPassword.Dto
{
    public class SetPasswordDto : UpdateDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        public string? NewUserPassword { get; set; }
        public string? NewUserPassword2 { get; set; }
    }
}
