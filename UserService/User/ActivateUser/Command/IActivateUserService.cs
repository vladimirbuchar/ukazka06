using Core.Base.Command.Update;
using Model.Edu.User;
using UserService.User.ActivateUser.Dto;

namespace UserService.User.ActivateUser.Command
{
    public interface IActivateUserService : IBaseUpdateCommand<UserDbo, ChangeUserActiveDto>
    {

    }
}
