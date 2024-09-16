using Core.DataTypes;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Delete
{
    public interface IBaseDeleteCommand : IBaseCommand
    {
        Task<Result> Execute(Guid objectId, Guid userId);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
