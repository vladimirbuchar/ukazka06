using Core.Base.Dto;
using System;

namespace EduServices.User.Dto
{
    public class ChangePasswordDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string OldUserPassword { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
    }
}
