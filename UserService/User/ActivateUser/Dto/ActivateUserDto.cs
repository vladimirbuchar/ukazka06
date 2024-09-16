using Core.Base.Dto;

namespace UserService.User.ActivateUser.Dto
{
    public class ActivateUserDto : BaseDto
    {
        public Guid LinkId { get; set; }
    }

    public class ChangeUserActiveDto : UpdateDto
    {
        public bool IsActive { get; set; }
    }
}
