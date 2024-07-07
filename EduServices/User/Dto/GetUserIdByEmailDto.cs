using Core.Base.Dto;

namespace Services.User.Dto
{
    public class GetUserIdByEmailDto : ListDto
    {
        public string UserEmail { get; set; }
    }
}
