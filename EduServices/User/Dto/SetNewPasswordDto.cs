using System;
using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class SetNewPasswordDto : ListDto
    {
        public Guid LinkId { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
