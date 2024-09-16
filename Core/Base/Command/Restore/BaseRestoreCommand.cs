using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Restore
{
    public class BaseRestoreCommand<Model, Repository> : BaseCommand, IBaseRestoreCommand
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        private readonly Repository _repository;

        public BaseRestoreCommand(Repository repository)
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

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
