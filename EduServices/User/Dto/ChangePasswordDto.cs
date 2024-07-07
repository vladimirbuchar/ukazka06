using System;
using System.Text.Json.Serialization;
using Core.Base.Dto;

namespace Services.User.Dto
{
    public class ChangePasswordDto : BaseDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string OldUserPassword { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
    }
}
