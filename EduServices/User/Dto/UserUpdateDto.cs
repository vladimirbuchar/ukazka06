using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class UserUpdateDto : UpdateDto
    {
        public PersonDto Person { get; set; }

    }
}
