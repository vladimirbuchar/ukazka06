using Core.Base.Dto;
using System;

namespace Services.User.Dto
{
    public class ActivateUserDto : BaseDto
    {
        public Guid LinkId { get; set; }
    }
}
