using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Branch;

namespace Repository.BranchRepository
{
    public class BranchRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<BranchDbo>(dbContext, memoryCache),
            IBranchRepository
    {
        protected override IQueryable<BranchDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<BranchDbo>()
                .Include(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.Country);
        }

        protected override IQueryable<BranchDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<BranchDbo>().Include(x => x.BranchTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<BranchDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
