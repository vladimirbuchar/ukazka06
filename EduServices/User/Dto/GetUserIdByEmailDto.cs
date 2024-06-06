using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class GetUserIdByEmailDto : ListDto
    {
        public string UserEmail { get; set; }

    }
}
