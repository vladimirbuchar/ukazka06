using Core.Base.Command.Update;
using Model.Edu.User;
using UserService.User.SetPassword.Dto;

namespace UserService.User.SetPassword.Command
{
    public interface ISetPasswordService : IBaseUpdateCommand<UserDbo, SetPasswordDto> { }
}
