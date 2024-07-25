using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<OrganizationCultureDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
