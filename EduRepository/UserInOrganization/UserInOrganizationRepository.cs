using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.UserInOrganization
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
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.CourseTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.User)
                .ThenInclude(x => x.Person)
                .Include(x => x.CourseLectors)
                .Include(x => x.CourseStudents)
                .Include(x => x.Organization)
                .ThenInclude(x => x.OrganizationStudyHours);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<UserInOrganizationDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
        protected override IQueryable<UserInOrganizationDbo> PrepareDropDownQuery()
        {
            return _dbContext.Set<UserInOrganizationDbo>().Include(x => x.OrganizationRole).Include(x => x.User).ThenInclude(x => x.Person);
        }

    }
}
