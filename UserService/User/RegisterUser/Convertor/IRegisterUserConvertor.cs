using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.RegisterUser.Dto;

namespace UserService.User.RegisterUser.Convertor
{
    public interface IRegisterUserConvertor : IBaseCreateConvertor<UserDbo, UserCreateDto> { }
}
