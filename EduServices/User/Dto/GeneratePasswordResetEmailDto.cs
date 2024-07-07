using Core.Base.Dto;

namespace Services.User.Dto
{
    public class GeneratePasswordResetEmailDto : BaseDto
    {
        public string UserEmail { get; set; }
    }
}
