using Core.Base.Command.Update;
using Model.Edu.User;
using UserService.User.UserUpdate.Dto;

namespace UserService.User.UserUpdate.Service
{
    public interface IUserUpdateService : IBaseUpdateCommand<UserDbo, UserUpdateDto> { }
}
