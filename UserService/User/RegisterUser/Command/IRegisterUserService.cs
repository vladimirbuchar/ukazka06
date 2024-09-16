using Core.Base.Command.Create;
using Model.Edu.User;
using UserService.User.RegisterUser.Dto;

namespace UserService.User.RegisterUser.Command
{
    public interface IRegisterUserService : IBaseCreateCommand<UserDbo, UserCreateDto> { }
}
