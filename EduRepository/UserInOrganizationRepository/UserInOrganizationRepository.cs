using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.UserInOrganizationRepository
{
    public class UserInOrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserInOrganizationDbo>(dbContext, memoryCache), IUserInOrganizationRepository
    {
        public override HashSet<UserInOrganizationDbo> GetEntities(bool deleted, Expression<Func<UserInOrganizationDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext
                    .Set<UserInOrganizationDbo>()
                    .Where(predicate)
                    .Where(x => x.IsDeleted == deleted && x.Organization.IsDeleted == false)
                    .Include(x => x.OrganizationRole)
                    .Include(x => x.Organization)
                    .Include(x => x.User)
                    .Include(x => x.User.Person)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<UserInOrganizationDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
