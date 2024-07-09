using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;

namespace Core.Base.Repository
{
    public abstract class BaseRepository(IMemoryCache memoryCache) : IBaseRepository
    {
        protected readonly IMemoryCache _memoryCache = memoryCache;

        /// <summary>
        /// save data to cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <param name="data"></param>
        /// <param name="expiration"></param>
        protected void SaveDataToCache<T>(string identificator, T data, DateTime expiration)
        {
            _ = _memoryCache.Set(identificator, data, new MemoryCacheEntryOptions() { AbsoluteExpiration = expiration });
        }

        /// <summary>
        /// get data from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <returns></returns>
        protected HashSet<T> GetDataFromCache<T>(string identificator)
        {
            return (HashSet<T>)_memoryCache.Get(identificator);
        }

        protected T GetFirstDataFromCache<T>(string identificator)
        {
            return (T)_memoryCache.Get(identificator);
        }
    }

    public abstract class BaseRepository<Model>(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository(memoryCache),
            IBaseRepository<Model>
        where Model : TableModel
    {
        protected readonly EduDbContext _dbContext = dbContext;

        /// <summary>
        /// save entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Model SaveEntity(Model obj, Guid userId)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj.Id == Guid.Empty)
            {
                obj.CreatedTime = DateTime.Now;
                obj.CreatedBy = userId;
                _ = _dbContext.Add(obj);
                _ = _dbContext.SaveChanges();
            }
            else
            {
                if (obj.IsDeleted || obj.IsSystemObject)
                {
                    return obj;
                }
                obj.UpdatedTime = DateTime.Now;
                obj.UpdatedBy = userId;
                _ = _dbContext.Update(obj);
                _ = _dbContext.SaveChanges();
            }
            _dbContext.ChangeTracker.Clear();
            return GetEntity(obj.Id);
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userId"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual void DeleteEntity(Guid guid, Guid userId)
        {
            Model entity = GetEntityWithoutInclude(guid) ?? throw new KeyNotFoundException(guid.ToString());
            DeleteEntity(entity, userId);
        }

        /// <summary>
        /// restore entity
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userId"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual void RestoreEntity(Guid guid, Guid userId)
        {
            Model entity = GetEntityWithoutInclude(guid) ?? throw new KeyNotFoundException(guid.ToString());
            entity.DeletedTime = null;
            entity.IsDeleted = false;
            entity.DeletedBy = null;
            _ = _dbContext.Update(entity);
            _ = _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        /// <summary>
        /// get organzation by object id
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public virtual Guid GetOrganizationId(Guid objectId)
        {
            return Guid.Empty;
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        public virtual void DeleteEntity(Model entity, Guid userId)
        {
            if (entity == null || entity.IsDeleted || entity.IsSystemObject)
            {
                return;
            }
            entity.DeletedTime = DateTime.Now;
            entity.IsDeleted = true;
            entity.DeletedBy = userId;
            _ = _dbContext.Update(entity);
            _ = _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        /// <summary>
        /// create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual Model CreateEntity(Model entity, Guid userId)
        {
            return SaveEntity(entity, userId);
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual Model UpdateEntity(Model entity, Guid userId)
        {
            return SaveEntity(entity, userId);
        }

        /// <summary>
        /// get entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Model GetEntity(Guid id)
        {
            IQueryable<Model> query = PrepareDetailQuery();
            return query.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// get entity without include
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Model GetEntityWithoutInclude(Guid id)
        {
            return _dbContext.Set<Model>().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// get entity with condition
        /// </summary>
        /// <param name="deleted"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual Model GetEntity(bool deleted, Expression<Func<Model, bool>> predicate = null)
        {
            IQueryable<Model> query = _dbContext.Set<Model>();
            return query.Where(x => x.IsDeleted == deleted).FirstOrDefault(predicate);
        }

        protected IQueryable<Model> PrepareOrderBy(
            IQueryable<Model> query,
            Expression<Func<Model, object>> orderBy = null,
            Expression<Func<Model, object>> orderByDesc = null
        )
        {
            if (orderBy != null && orderByDesc == null)
            {
                query = query.OrderBy(orderBy);
            }
            else if (orderByDesc != null && orderBy == null)
            {
                query = query.OrderByDescending(orderByDesc);
            }
            return query;
        }

        protected IQueryable<Model> PrepareLimit(IQueryable<Model> query, int page = 0, int itemCount = 0)
        {
            if (page > 0 && itemCount > 0)
            {
                query = query.Skip((page - 1) * itemCount);
                query = query.Take(itemCount);
            }
            return query;
        }

        protected IQueryable<Model> PrepareWhere(
            IQueryable<Model> query,
            bool deleted,
            Expression<Func<Model, bool>> predicate = null,
            Expression<Func<Model, bool>> customPredicate = null
        )
        {
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = query.Where(x => x.IsDeleted == deleted);
            if (customPredicate != null)
            {
                query = query.Where(customPredicate);
            }
            return query;
        }

        protected virtual IQueryable<Model> PrepareDetailQuery()
        {
            return _dbContext.Set<Model>();
        }

        protected virtual IQueryable<Model> PrepareListQuery()
        {
            return _dbContext.Set<Model>();
        }

        /// <summary>
        /// get entity list
        /// </summary>
        /// <param name="deleted"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<Model>> GetEntities(
            bool deleted,
            Expression<Func<Model, bool>> predicate = null,
            Expression<Func<Model, bool>> customPredicate = null,
            Expression<Func<Model, object>> orderBy = null,
            Expression<Func<Model, object>> orderByDesc = null,
            int page = 0,
            int itemCount = 0
        )
        {
            IQueryable<Model> query = PrepareListQuery();
            query = PrepareWhere(query, deleted, predicate, customPredicate);
            query = PrepareOrderBy(query, orderBy, orderByDesc);
            query = PrepareLimit(query, page, itemCount);
            return await query.ToListAsync();
        }
    }
}
