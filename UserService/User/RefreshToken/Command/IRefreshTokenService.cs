using Core.Base.Command;

namespace UserService.User.RefreshToken.Command
{
    public interface IRefreshTokenService : IBaseCommand
    {
        Task<string> Execute(Guid userId);
    }
}
