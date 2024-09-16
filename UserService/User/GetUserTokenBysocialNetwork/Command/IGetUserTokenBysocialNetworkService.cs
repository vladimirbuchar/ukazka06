using Core.Base.Command;
using UserService.User.GetUserTokenBysocialNetwork.Dto;

namespace UserService.User.GetUserTokenBysocialNetwork.Command
{
    public interface IGetUserTokenBysocialNetworkService : IBaseCommand
    {
        Task<string> Execute(LoginUserSocialNetworkDto loginSocialNetwork, string culture);
    }
}
