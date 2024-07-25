using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.MultipleDelete
{
    public abstract class BaseServiceMultipleDelete<Model, Repository> : BaseServiceNew, IBaseServiceMultipleDelete<Model>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
    {
        private readonly Repository _repository;

        public BaseServiceMultipleDelete(Repository repository)
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
    }


}
