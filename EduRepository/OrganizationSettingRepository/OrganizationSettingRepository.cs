using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.OrganizationSetting;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.OrganizationSettingRepository
{
    public class OrganizationSettingRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<OrganizationSettingDbo>(dbContext, memoryCache),
            IOrganizationSettingRepository
    {
        public override async Task<OrganizationSettingDbo> GetEntity(bool deleted, Expression<Func<OrganizationSettingDbo, bool>> predicate = null)
        {
            return await _dbContext.Set<OrganizationSettingDbo>().Include(x => x.Organization).Where(x => x.IsDeleted == deleted).FirstOrDefaultAsync(predicate);
        }
    }
}
