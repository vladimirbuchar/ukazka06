using Core.Base.Dto;

namespace UserService.User.SetNewPassword.Dto
{
    public class SetNewPasswordDto : BaseDto
    {
        public Guid LinkId { get; set; }
        public string? Password1 { get; set; }
        public string? Password2 { get; set; }
    }
}
