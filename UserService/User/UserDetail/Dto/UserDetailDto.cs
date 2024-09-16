using Core.Base.Dto;
using UserService.User.Dto;

namespace UserService.User.UserDetail.Dto
{
    public class UserDetailDto : DetailDto
    {
        public string? UserEmail { get; set; }
        public required PersonDto Person { get; set; }
    }
}
