using Core.Base.Dto;
using System;
using System.Text.Json.Serialization;

namespace Services.User.Dto
{
    public class SetPasswordDto : BaseDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
    }
}
