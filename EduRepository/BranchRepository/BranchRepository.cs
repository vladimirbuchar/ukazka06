using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.BranchRepository
{
    public class BranchRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<BranchDbo>(dbContext, memoryCache), IBranchRepository
    {
        public override HashSet<BranchDbo> GetEntities(bool deleted, Expression<Func<BranchDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<BranchDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)
                .Include(x => x.BranchTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture)];
        }

        public override BranchDbo GetEntity(Guid id)
        {
            return _dbContext.Set<BranchDbo>().Include(x => x.BranchTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<BranchDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
