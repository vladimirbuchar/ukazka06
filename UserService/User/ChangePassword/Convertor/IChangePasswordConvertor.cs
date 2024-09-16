using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.ChangePassword.Dto;

namespace UserService.User.ChangePassword.Convertor
{
    public interface IChangePasswordConvertor : IBaseUpdateConvertor<UserDbo, ChangePasswordDto> { }
}
