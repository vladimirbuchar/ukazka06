using Core.DataTypes;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Restore
{
    public interface IBaseRestoreCommand : IBaseCommand
    {
        Task<Result> Execute(Guid objectId, Guid userId);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
