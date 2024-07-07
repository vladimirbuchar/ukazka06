using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace Repository.UserInOrganizationRepository
{
    public class UserInOrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserInOrganizationDbo>(dbContext, memoryCache), IUserInOrganizationRepository
    {
        public override HashSet<UserInOrganizationDbo> GetEntities(
            bool deleted,
            Expression<Func<UserInOrganizationDbo, bool>> predicate = null,
            Expression<Func<UserInOrganizationDbo, object>> orderBy = null,
            Expression<Func<UserInOrganizationDbo, object>> orderByDesc = null
        )
        {
            return
            [
                .. _dbContext
                    .Set<UserInOrganizationDbo>()
                    .Include(x => x.OrganizationRole)
                    .Include(x => x.Organization)
                    .Include(x => x.User)
                    .ThenInclude(x => x.Person)
                    .Where(predicate)
                    .Where(x => x.IsDeleted == deleted && x.Organization.IsDeleted == false)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<UserInOrganizationDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
