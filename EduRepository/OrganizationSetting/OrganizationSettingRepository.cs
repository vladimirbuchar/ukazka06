using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.OrganizationSetting;
using System.Linq;

namespace Repository.OrganizationSetting
{
    public class OrganizationSettingRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<OrganizationSettingDbo>(dbContext, memoryCache),
            IOrganizationSettingRepository
    {
        protected override IQueryable<OrganizationSettingDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<OrganizationSettingDbo>()
                .Include(x => x.Organization);
        }
    }
}
