using Core.Base.Dto;
using System;

namespace EduServices.User.Dto
{
    public class SetPasswordDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
    }
}
