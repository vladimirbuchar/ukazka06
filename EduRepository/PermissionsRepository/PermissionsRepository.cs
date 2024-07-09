using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.System;

namespace Repository.PermissionsRepository
{
    public class PermissionsRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<PermissionsDbo>(dbContext, memoryCache),
            IPermissionsRepository
    {
        protected override IQueryable<PermissionsDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<PermissionsDbo>()
                .Include(x => x.Route)
                .Include(x => x.OrganizationRole)
                .ThenInclude(x => x.UserInOrganizations.Where(x => x.IsDeleted == false));
        }

        protected override IQueryable<PermissionsDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<PermissionsDbo>()
                .Include(x => x.Route)
                .Include(x => x.OrganizationRole)
                .ThenInclude(x => x.UserInOrganizations.Where(x => x.IsDeleted == false));
        }
    }
}
