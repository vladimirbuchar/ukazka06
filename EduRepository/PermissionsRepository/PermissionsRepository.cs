using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.PermissionsRepository
{
    public class PermissionsRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<PermissionsDbo>(dbContext, memoryCache), IPermissionsRepository
    {
        public override HashSet<PermissionsDbo> GetEntities(bool deleted, Expression<Func<PermissionsDbo, bool>> predicate = null, Expression<Func<PermissionsDbo, object>> orderBy = null, Expression<Func<PermissionsDbo, object>> orderByDesc = null)
        {

            return predicate == null
                 ? ([
                     .. _dbContext
                    .Set<PermissionsDbo>()
                    .Include(x=>x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x=> x.UserInOrganizations.Where(x => x.IsDeleted == false))
                    .Where(x => x.IsDeleted == deleted)
                 ])
                 : ([
                     .. _dbContext
                    .Set<PermissionsDbo>()
                    .Include(x=>x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x=> x.UserInOrganizations.Where(x => x.IsDeleted == false))
                    .Where(predicate)
                    .Where(x => x.IsDeleted == deleted)
                 ]);
        }

        public override PermissionsDbo GetEntity(Guid id)
        {
            return
                _dbContext
                    .Set<PermissionsDbo>()
                    .Include(x => x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x => x.UserInOrganizations.Where(x => x.IsDeleted == false))
                    .FirstOrDefault(x => x.Id == id);
        }
    }
}
