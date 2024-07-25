using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.OrganizationStudyHour;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.OrganizationHoursRepository
{
    public class OrganizationStudyHourRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<OrganizationStudyHourDbo>(dbContext, memoryCache),
            IOrganizationStudyHourRepository
    {
        protected override IQueryable<OrganizationStudyHourDbo> PrepareListQuery()
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().Include(x => x.ActiveFrom).Include(x => x.ActiveTo);
        }

        protected override IQueryable<OrganizationStudyHourDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().Include(x => x.ActiveFrom).Include(x => x.ActiveTo);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<OrganizationStudyHourDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
