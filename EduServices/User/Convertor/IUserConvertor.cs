using Core.Base.Convertor;
using Model.Edu.User;
using Services.User.Dto;

namespace Services.User.Convertor
{
    public interface IUserConvertor : IBaseConvertor<UserDbo, UserCreateDto, UserListDto, UserDetailDto, UserUpdateDto>
    {
        UserTokenDto ConvertToWebModel(UserDbo loginUser);
    }
}
