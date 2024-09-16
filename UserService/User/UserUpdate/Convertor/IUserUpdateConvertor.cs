using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.UserUpdate.Dto;

namespace UserService.User.UserUpdate.Convertor
{
    public interface IUserUpdateConvertor : IBaseUpdateConvertor<UserDbo, UserUpdateDto> { }
}
