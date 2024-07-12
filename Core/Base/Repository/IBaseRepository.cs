using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using Model;

namespace Core.Base.Repository
{
    public interface IBaseRepository { }

    public interface IBaseRepository<Model> : IBaseRepository
        where Model : TableModel
    {
        void DeleteEntity(Guid guid, Guid userId);
        void DeleteEntity(Model entity, Guid userId);
        void RestoreEntity(Guid guid, Guid userId);
        Model GetEntity(Guid id);
        Model GetEntity(bool deleted, Expression<Func<Model, bool>> predicate = null);
        Model CreateEntity(Model entity, Guid userId);
        Model UpdateEntity(Model entity, Guid userId);
        Task<List<Model>> GetEntities(
            bool deleted,
            Expression<Func<Model, bool>> predicate = null,
            Expression<Func<Model, bool>> customPredicate = null,
            Expression<Func<Model, object>> orderBy = null,
            SortDirection sortDirection = SortDirection.Ascending,
            int page = 0,
            int itemCount = 0
        );
        Guid GetOrganizationId(Guid objectId);
    }
}
