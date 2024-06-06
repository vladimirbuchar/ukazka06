using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class UserDetailDto : DetailDto
    {
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; }
    }
}
