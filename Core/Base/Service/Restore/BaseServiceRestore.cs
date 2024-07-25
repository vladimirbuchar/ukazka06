using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Restore
{
    public class BaseServiceRestore<Model, Repository> : BaseServiceNew, IBaseServiceRestore
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        private readonly Repository _repository;
        public BaseServiceRestore(Repository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// restore object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="userId"></param>
        public virtual async Task<Result> Execute(Guid objectId, Guid userId)
        {
            await _repository.RestoreEntity(objectId, userId);
            return new Result();
        }
    }
}
