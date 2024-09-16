using Core.Base.Command.Detail;
using Model.Edu.User;
using UserService.User.UserDetail.Dto;

namespace UserService.User.UserDetail.Command
{
    public interface IUserDetailService : IBaseDetailCommand<UserDbo, UserDetailDto> { }
}
