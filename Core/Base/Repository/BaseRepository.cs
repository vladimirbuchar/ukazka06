using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

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

    public abstract class BaseRepository<Model>(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository(memoryCache), IBaseRepository<Model>
        where Model : TableModel
    {
        protected readonly EduDbContext _dbContext = dbContext;
        protected string cacheName = string.Empty;

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
            return obj;
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
            IQueryable<Model> query = _dbContext.Set<Model>();
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
        /// <summary>
        /// get entity list
        /// </summary>
        /// <param name="deleted"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual HashSet<Model> GetEntities(bool deleted, Expression<Func<Model, bool>> predicate = null)
        {
            return predicate != null ? [.. _dbContext.Set<Model>().Where(predicate).Where(x => x.IsDeleted == deleted)] : [.. _dbContext.Set<Model>().Where(x => x.IsDeleted == deleted)];
        }
    }
}
