using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.LinkLifeTime;

namespace Repository.LinkLifeTimeRepository
{
    public class LinkLifeTimeRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<LinkLifeTimeDbo>(dbContext, memoryCache),
            ILinkLifeTimeRepository
    {
        public override LinkLifeTimeDbo GetEntity(bool deleted, Expression<Func<LinkLifeTimeDbo, bool>> predicate = null)
        {
            return _dbContext.Set<LinkLifeTimeDbo>().Include(x => x.User).Where(x => x.IsDeleted == deleted).FirstOrDefault(predicate);
        }
    }
}
