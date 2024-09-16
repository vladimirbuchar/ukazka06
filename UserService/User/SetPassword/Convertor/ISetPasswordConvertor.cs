using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.SetPassword.Dto;

namespace UserService.User.SetPassword.Convertor
{
    public interface ISetPasswordConvertor : IBaseUpdateConvertor<UserDbo, SetPasswordDto> { }
}
