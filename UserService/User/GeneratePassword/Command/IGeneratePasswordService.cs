using Core.Base.Command;

namespace UserService.User.GeneratePassword.Command
{
    public interface IGeneratePasswordService : IBaseCommand
    {
        Task<string> Execute();
    }
}
