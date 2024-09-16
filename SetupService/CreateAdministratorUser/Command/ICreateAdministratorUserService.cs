using Core.Base.Command;
using Core.DataTypes;

namespace SetupService.CreateAdministratorUser.Command
{
    public interface ICreateAdministratorUserService : IBaseCommand
    {
        Task<Result> Execute(Guid roleId);
    }
}