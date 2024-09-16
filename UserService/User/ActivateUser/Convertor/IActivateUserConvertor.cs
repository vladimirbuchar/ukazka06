using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.ActivateUser.Dto;

namespace UserService.User.ActivateUser.Convertor
{
    public interface IActivateUserConvertor : IBaseUpdateConvertor<UserDbo, ChangeUserActiveDto>
    {
    }
}