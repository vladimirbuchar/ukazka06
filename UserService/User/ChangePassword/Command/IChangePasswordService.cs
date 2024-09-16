using Core.Base.Command.Update;
using Model.Edu.User;
using UserService.User.ChangePassword.Dto;

namespace UserService.User.ChangePassword.Command
{
    public interface IChangePasswordService : IBaseUpdateCommand<UserDbo, ChangePasswordDto> { }
}
