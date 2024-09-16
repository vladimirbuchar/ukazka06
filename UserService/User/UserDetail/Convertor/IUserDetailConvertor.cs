using Core.Base.Convertor;
using Model.Edu.User;
using UserService.User.UserDetail.Dto;

namespace UserService.User.UserDetail.Convertor
{
    public interface IUserDetailConvertor : IBaseDetailConvertor<UserDbo, UserDetailDto> { }
}
