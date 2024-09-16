using Core.Base.Dto;
using System.Text.Json.Serialization;
using UserService.User.Dto;

namespace UserService.User.RegisterUser.Dto
{
    public class UserCreateDto : CreateDto
    {


        public string? UserPassword { get; set; }
        public string? UserPassword2 { get; set; }
        public string? UserEmail { get; set; }
        public PersonDto Person { get; set; } = new PersonDto();

        [JsonIgnore]
        public bool AllowClassicLogin { get; set; } = true;

        [JsonIgnore]
        public bool UserMustChangePassword { get; set; } = false;
        [JsonIgnore]
        public Guid RoleId { get; set; }
    }
}
