using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class UserListDto : ListDto
    {
        public string UserEmail { get; set; }
        public PersonDto PersonName { get; set; }
    }
}
