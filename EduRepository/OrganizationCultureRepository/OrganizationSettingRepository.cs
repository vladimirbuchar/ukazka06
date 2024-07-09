using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace Repository.OrganizationCultureRepository
{
    public class OrganizationCultureRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<OrganizationCultureDbo>(dbContext, memoryCache),
            IOrganizationCultureRepository
    {
        protected override IQueryable<OrganizationCultureDbo> PrepareListQuery()
        {
            return _dbContext.Set<OrganizationCultureDbo>().Include(x => x.Culture);
        }

        protected override IQueryable<OrganizationCultureDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<OrganizationCultureDbo>().Include(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<OrganizationCultureDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
