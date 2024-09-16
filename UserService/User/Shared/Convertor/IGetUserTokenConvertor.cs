using Model.Edu.User;
using UserService.User.Shared.Dto;

namespace UserService.User.Shared.Convertor
{
    public interface IGetUserTokenConvertor
    {
        UserTokenDto ConvertToWebModel(UserDbo loginUser);
    }
}
