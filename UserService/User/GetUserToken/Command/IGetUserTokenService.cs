using Core.Base.Command;
using UserService.User.GetUserToken.Dto;

namespace UserService.User.GetUserToken.Command
{
    public interface IGetUserTokenService : IBaseCommand
    {
        Task<string> Execute(GetUserTokenDto loginData);
    }
}
