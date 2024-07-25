using Core.Base.Paging;
using Core.Base.Sort;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Repository
{
    public interface IBaseRepository { }

    public interface IBaseRepository<Model> : IBaseRepository
        where Model : TableModel
    {
        Task DeleteEntity(Guid guid, Guid userId);
        Task DeleteEntity(Model entity, Guid userId);
        Task RestoreEntity(Guid guid, Guid userId);
        Task<Model> GetEntity(Guid id);
        Task<Model> GetEntity(bool deleted, Expression<Func<Model, bool>> predicate = null);
        Task<Model> CreateEntity(Model entity, Guid userId);
        Task<Model> UpdateEntity(Model entity, Guid userId);
        Task<List<Model>> GetEntities(
            bool deleted,
            Expression<Func<Model, bool>> predicate = null,
            Expression<Func<Model, bool>> customPredicate = null,
            List<BaseSort<Model>> orderBy = null,
            BasePaging paging = null);

        Task<Guid> GetOrganizationId(Guid objectId);
        Task<int> GetTotalCount(bool deleted,
            Expression<Func<Model, bool>> predicate = null,
            Expression<Func<Model, bool>> customPredicate = null);
        Task<Guid> GetOrganizationByFileId(Guid objectId);
    }
}
