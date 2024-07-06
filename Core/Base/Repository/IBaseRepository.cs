using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        HashSet<Model> GetEntities(bool deleted, Expression<Func<Model, bool>> predicate = null, Expression<Func<Model, object>> orderBy = null, Expression<Func<Model, object>> orderByDesc = null);
        Guid GetOrganizationId(Guid objectId);
    }
}
