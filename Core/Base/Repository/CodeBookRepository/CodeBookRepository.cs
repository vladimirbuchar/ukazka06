using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Base.Repository.CodeBookRepository
{
    public class CodeBookRepository<Model>(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<Model>(dbContext, memoryCache), ICodeBookRepository<Model>
        where Model : CodeBook
    {
        public override HashSet<Model> GetEntities(bool deleted, Expression<Func<Model, bool>> predicate = null, Expression<Func<Model, object>> orderBy = null, Expression<Func<Model, object>> orderByDesc = null)
        {
            string name = string.Format("{0}_cblist", typeof(Model).Name);
            HashSet<Model> data = GetDataFromCache<Model>(name);
            if (data == null)
            {
                data = [.. base.GetEntities(false, predicate, x => x.Priority)];
                SaveDataToCache(name, data, DateTime.Now.AddMinutes(2));
                return data;
            }
            return data;
        }
    }
}
