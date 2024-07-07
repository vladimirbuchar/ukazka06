using System;
using System.ComponentModel.DataAnnotations;
using Core.Base.Dto;

namespace Services.User.Dto
{
    public class LoginUserDto : BaseDto
    {
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
