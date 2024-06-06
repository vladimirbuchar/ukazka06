using Model;
using System;
using System.Collections.Generic;

namespace Core.Base.Repository
{
    public interface IBaseRepository { }

    public interface IBaseRepository<Model> : IBaseRepository
        where Model : TableModel
    {
        void DeleteEntity(Guid guid, Guid userId);
        void DeleteEntity(Model entity, Guid userId);
        void RestoreEntity(Guid guid, Guid userId);
        Model GetEntity(Guid Id);
        Model GetEntity(bool deleted, System.Linq.Expressions.Expression<Func<Model, bool>> predicate = null);
        Model CreateEntity(Model entity, Guid userId);
        Model UpdateEntity(Model entity, Guid userId);
        HashSet<Model> GetEntities(bool deleted, System.Linq.Expressions.Expression<Func<Model, bool>> predicate = null);
        Guid GetOrganizationId(Guid objectId);
    }
}
