using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Delete
{
    public abstract class BaseDeleteCommand<TModel, TRepository> : IBaseDeleteCommand
        where TRepository : IBaseRepository<TModel>
        where TModel : TableModel
    {
        protected readonly TRepository _repository;

        public BaseDeleteCommand(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<Result> Execute(Guid objectId, Guid userId)
        {
            await _repository.DeleteEntity(objectId, userId);
            return new Result();
        }

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
