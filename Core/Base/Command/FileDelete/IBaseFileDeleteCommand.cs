using Core.DataTypes;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.FileDelete
{
    public interface IBaseFileDeleteCommand
    {
        Task<Result> Execute(Guid id, Guid userId);
        Task<Guid> GetOrganizationIdByFileId(Guid objectId);
    }
}
