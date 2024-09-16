using Core.Base.Command;
using SetupService.CheckUser.Dto;

namespace SetupService.CheckUser.Command
{
    public interface ICheckUserService : IBaseCommand
    {
        Task<bool> Execute(SetupLoginDto setupLogin);
    }
}