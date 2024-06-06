using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.PermissionsRepository
{
    public class PermissionsRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<PermissionsDbo>(dbContext, memoryCache), IPermissionsRepository
    {
        public override HashSet<PermissionsDbo> GetEntities(bool deleted, Expression<Func<PermissionsDbo, bool>> predicate = null)
        {

            return predicate == null
                 ? ([
                     .. _dbContext
                    .Set<PermissionsDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Include(x=>x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x=> x.UserInOrganizations)
                 ])
                 : ([
                     .. _dbContext
                    .Set<PermissionsDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Include(x=>x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x=> x.UserInOrganizations)
                    .Where(predicate)
                 ]);
        }

        public override PermissionsDbo GetEntity(Guid id)
        {
            return

                _dbContext
                    .Set<PermissionsDbo>()
                    .Include(x => x.Route)
                    .Include(x => x.OrganizationRole)
                    .ThenInclude(x => x.UserInOrganizations)
                    .Where(x => x.Id == id).FirstOrDefault();

        }
    }
}
