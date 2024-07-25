using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Delete
{
    public abstract class BaseServiceDelete<Model, Repository> : IBaseServiceDelete
        where Repository : IBaseRepository<Model>
        where Model : TableModel
    {
        private readonly Repository _repository;
        public BaseServiceDelete(Repository repository)
        {
            _repository = repository;
        }
        public virtual async Task<Result> Execute(Guid objectId, Guid userId)
        {
            await _repository.DeleteEntity(objectId, userId);
            return new Result();
        }
    }


}
