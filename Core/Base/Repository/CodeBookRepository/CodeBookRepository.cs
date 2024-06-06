using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Base.Repository.CodeBookRepository
{
    public class CodeBookRepository<Model>(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<Model>(dbContext, memoryCache), ICodeBookRepository<Model>
        where Model : CodeBook
    {
        /// <summary>
        /// get items in code book
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public HashSet<Model> GetCodeBookItems(System.Linq.Expressions.Expression<Func<Model, bool>> predicate = null)
        {
            string name = string.Format("{0}_cblist", typeof(Model).Name);
            HashSet<Model> data = GetDataFromCache<Model>(name);
            if (data == null)
            {
                data = [.. GetEntities(false, predicate).OrderBy(x => x.Priority)];
                SaveDataToCache(name, data, DateTime.Now.AddMinutes(2));
                return data;
            }
            return data;
        }
    }
}
