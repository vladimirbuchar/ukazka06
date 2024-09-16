using Core.Base.Dto;

namespace UserService.User.GeneratePasswordResetEmail.Dto
{
    public class GeneratePasswordResetEmailDto : BaseDto
    {
        public string? UserEmail { get; set; }
    }
}
