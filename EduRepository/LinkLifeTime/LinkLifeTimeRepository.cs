using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.LinkLifeTime;
using System.Linq;

namespace Repository.LinkLifeTime
{
    public class LinkLifeTimeRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<LinkLifeTimeDbo>(dbContext, memoryCache),
            ILinkLifeTimeRepository
    {


        protected override IQueryable<LinkLifeTimeDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<LinkLifeTimeDbo>().Include(x => x.User);
        }
    }
}
