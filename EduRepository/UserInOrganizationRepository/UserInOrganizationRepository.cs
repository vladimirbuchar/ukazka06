using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Branch;
using Model.Link;

namespace Repository.UserInOrganizationRepository
{
    public class UserInOrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<UserInOrganizationDbo>(dbContext, memoryCache),
            IUserInOrganizationRepository
    {
        protected override IQueryable<UserInOrganizationDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<UserInOrganizationDbo>()
                .Include(x => x.OrganizationRole)
                .Include(x => x.Organization)
                .Include(x => x.User)
                .ThenInclude(x => x.Person);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<UserInOrganizationDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
