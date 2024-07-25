using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.LinkLifeTime;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.LinkLifeTimeRepository
{
    public class LinkLifeTimeRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<LinkLifeTimeDbo>(dbContext, memoryCache),
            ILinkLifeTimeRepository
    {
        public override async Task<LinkLifeTimeDbo> GetEntity(bool deleted, Expression<Func<LinkLifeTimeDbo, bool>> predicate = null)
        {
            return await _dbContext.Set<LinkLifeTimeDbo>().Include(x => x.User).Where(x => x.IsDeleted == deleted).FirstOrDefaultAsync(predicate);
        }
        protected override IQueryable<LinkLifeTimeDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<LinkLifeTimeDbo>().Include(x => x.User);
        }
    }
}
