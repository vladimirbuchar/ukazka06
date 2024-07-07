using Core.Base.Dto;

namespace Services.User.Dto
{
    public class UserUpdateDto : UpdateDto
    {
        public PersonDto Person { get; set; }
    }
}
