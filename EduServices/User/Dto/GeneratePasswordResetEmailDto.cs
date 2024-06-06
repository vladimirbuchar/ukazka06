using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class GeneratePasswordResetEmailDto : BaseDto
    {
        public string UserEmail { get; set; }
    }
}
