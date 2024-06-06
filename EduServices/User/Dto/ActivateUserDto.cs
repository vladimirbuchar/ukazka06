using System;
using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class ActivateUserDto : ListDto
    {
        public Guid LinkId { get; set; }
    }
}
