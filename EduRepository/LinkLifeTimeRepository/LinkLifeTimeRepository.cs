using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.LinkLifeTime;
using System;
using System.Linq;

namespace EduRepository.LinkLifeTimeRepository
{
    public class LinkLifeTimeRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<LinkLifeTimeDbo>(dbContext, memoryCache), ILinkLifeTimeRepository
    {
        public override LinkLifeTimeDbo GetEntity(Guid id)
        {
            return _dbContext.Set<LinkLifeTimeDbo>().Include(x => x.User).FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
