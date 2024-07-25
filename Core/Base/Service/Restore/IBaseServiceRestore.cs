using Core.DataTypes;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Restore
{
    public interface IBaseServiceRestore : IBaseServiceNew
    {
        Task<Result> Execute(Guid objectId, Guid userId);
    }

}
