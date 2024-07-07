using System;
using Core.Base.Dto;

namespace Services.User.Dto
{
    public class ActivateUserDto : BaseDto
    {
        public Guid LinkId { get; set; }
    }
}
