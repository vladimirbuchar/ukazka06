using Core.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace Services.User.Dto
{
    public class LoginUserAdminDto : BaseDto
    {
        public string UserEmail { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
