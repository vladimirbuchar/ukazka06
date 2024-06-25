using Core.Base.Dto;
using System;

namespace EduServices.User.Dto
{
    public class ActivateUserDto : BaseDto
    {
        public Guid LinkId { get; set; }
    }
}
