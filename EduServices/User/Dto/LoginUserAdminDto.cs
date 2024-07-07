using System.ComponentModel.DataAnnotations;
using Core.Base.Dto;

namespace Services.User.Dto
{
    public class LoginUserAdminDto : BaseDto
    {
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
