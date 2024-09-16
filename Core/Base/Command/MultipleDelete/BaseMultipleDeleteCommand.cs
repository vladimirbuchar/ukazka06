using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.MultipleDelete
{
    public abstract class BaseMultipleDeleteCommand<Model, Repository> : BaseCommand, IBaseMultipleDeleteCommand<Model>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
    {
        private readonly Repository _repository;

        public BaseMultipleDeleteCommand(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Execute(Expression<Func<Model, bool>> predicate, Guid userId)
        {
            List<Guid> ids = (await _repository.GetEntities(false, predicate)).Select(x => x.Id).ToList();
            foreach (Guid id in ids)
            {
                await _repository.DeleteEntity(id, userId);
            }
            return new Result();
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }
    }
}
