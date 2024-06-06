using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.OrganizationSetting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.OrganizationSettingRepository
{
    public class OrganizationSettingRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationSettingDbo>(dbContext, memoryCache), IOrganizationSettingRepository
    {
        public override OrganizationSettingDbo GetEntity(bool deleted, Expression<Func<OrganizationSettingDbo, bool>> predicate = null)
        {
            return _dbContext.Set<OrganizationSettingDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.Organization).FirstOrDefault();
        }
    }
}
