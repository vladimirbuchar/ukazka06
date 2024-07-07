using System;
using Core.Base.Dto;

namespace Services.User.Dto
{
    public class SetNewPasswordDto : BaseDto
    {
        public Guid LinkId { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
