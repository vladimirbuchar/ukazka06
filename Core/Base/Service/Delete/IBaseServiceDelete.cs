using Core.DataTypes;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Delete
{
    public interface IBaseServiceDelete : IBaseServiceNew

    {
        Task<Result> Execute(Guid objectId, Guid userId);
    }

}
