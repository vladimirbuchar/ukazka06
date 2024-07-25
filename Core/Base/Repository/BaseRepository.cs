using Core.Base.Paging;
using Core.Base.Sort;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

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
        private async Task<Model> SaveEntity(Model obj, Guid userId)
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
                _ = await _dbContext.SaveChangesAsync();
            }
            else
            {
                if (obj.IsDeleted || obj.IsSystemObject)
                {
                    return await GetEntity(obj.Id); ;
                }
                obj.UpdatedTime = DateTime.Now;
                obj.UpdatedBy = userId;
                _ = _dbContext.Update(obj);
                _ = await _dbContext.SaveChangesAsync();
            }
            _dbContext.ChangeTracker.Clear();
            return await GetEntity(obj.Id);
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userId"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual async Task DeleteEntity(Guid guid, Guid userId)
        {
            Model entity = await GetEntityWithoutInclude(guid) ?? throw new KeyNotFoundException(guid.ToString());
            await DeleteEntity(entity, userId);
        }

        /// <summary>
        /// restore entity
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="userId"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual async Task RestoreEntity(Guid guid, Guid userId)
        {
            Model entity = await GetEntityWithoutInclude(guid) ?? throw new KeyNotFoundException(guid.ToString());
            entity.DeletedTime = null;
            entity.IsDeleted = false;
            entity.DeletedBy = null;
            _ = _dbContext.Update(entity);
            _ = await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }

        /// <summary>
        /// get organzation by object id
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public virtual async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        public virtual async Task<Guid> GetOrganizationByFileId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        public virtual async Task DeleteEntity(Model entity, Guid userId)
        {
            if (entity == null || entity.IsDeleted || entity.IsSystemObject)
            {
                return;
            }
            entity.DeletedTime = DateTime.Now;
            entity.IsDeleted = true;
            entity.DeletedBy = userId;
            _ = _dbContext.Update(entity);
            _ = await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }

        /// <summary>
        /// create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual async Task<Model> CreateEntity(Model entity, Guid userId)
        {
            return await SaveEntity(entity, userId);
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual async Task<Model> UpdateEntity(Model entity, Guid userId)
        {
            return await SaveEntity(entity, userId);
        }

        /// <summary>
        /// get entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<Model> GetEntity(Guid id)
        {
            IQueryable<Model> query = PrepareDetailQuery();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// get entity without include
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Model> GetEntityWithoutInclude(Guid id)
        {
            return await _dbContext.Set<Model>().FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// get entity with condition
        /// </summary>
        /// <param name="deleted"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<Model> GetEntity(bool deleted, Expression<Func<Model, bool>> predicate = null)
        {
            return await PrepareDetailQuery().Where(x => x.IsDeleted == deleted).FirstOrDefaultAsync(predicate);
        }

        protected IQueryable<Model> PrepareOrderBy(
            IQueryable<Model> query,
            List<BaseSort<Model>> orderBy = null
        )
        {
            if (orderBy != null && orderBy.Count > 0)
            {
                IOrderedQueryable<Model> orderedQuery = orderBy[0].SortDirection == SortDirection.Ascending ? query.OrderBy(orderBy[0].Sort) : query.OrderByDescending(orderBy[0].Sort);
                for (int i = 1; i < orderBy.Count; i++)
                {
                    orderedQuery = orderBy[i].SortDirection == SortDirection.Ascending ? orderedQuery.ThenBy(orderBy[i].Sort) : orderedQuery.ThenByDescending(orderBy[i].Sort);
                }
                query = orderedQuery;
            }
            return query;
        }

        protected IQueryable<Model> PrepareLimit(IQueryable<Model> query, BasePaging paging)
        {
            paging ??= new BasePaging();
            int page = paging.Page;
            int itemCount = paging.ItemCount;
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
            List<BaseSort<Model>> orderBy = null,
            BasePaging paging = null
        )
        {

            IQueryable<Model> query = PrepareListQuery();
            query = PrepareWhere(query, deleted, predicate, customPredicate);
            query = PrepareOrderBy(query, orderBy);
            query = PrepareLimit(query, paging);
            return await query.ToListAsync();
        }

        public async Task<int> GetTotalCount(bool deleted, Expression<Func<Model, bool>> predicate = null, Expression<Func<Model, bool>> customPredicate = null)
        {
            IQueryable<Model> query = PrepareListQuery();
            query = PrepareWhere(query, deleted, predicate, customPredicate);
            return await query.CountAsync();
        }
    }
}
