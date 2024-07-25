using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.StudentInGroupRepository
{
    public class StudentInGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentInGroupDbo>(dbContext, memoryCache),
            IStudentInGroupRepository
    {
        protected override IQueryable<StudentInGroupDbo> PrepareListQuery()
        {
            return _dbContext.Set<StudentInGroupDbo>().Include(x => x.UserInOrganization).ThenInclude(x => x.User).ThenInclude(x => x.Person);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<StudentInGroupDbo>().Include(x => x.StudentGroup).FirstOrDefaultAsync(x => x.Id == objectId)).StudentGroup.OrganizationId;
        }
    }
}
