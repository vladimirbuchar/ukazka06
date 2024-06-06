using Core.Base.Convertor;
using EduServices.User.Dto;
using Model.Tables.Edu.User;

namespace EduServices.User.Convertor
{
    public interface IUserConvertor : IBaseConvertor<UserDbo, UserCreateDto, UserListDto, UserDetailDto, UserUpdateDto>
    {
        UserTokenDto ConvertToWebModel(UserDbo loginUser);
    }
}
