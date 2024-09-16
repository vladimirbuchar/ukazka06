using Core.Base.Dto;
using UserService.User.Dto;

namespace UserService.User.UserUpdate.Dto
{
    public class UserUpdateDto : UpdateDto
    {
        public required PersonDto Person { get; set; }
    }
}
