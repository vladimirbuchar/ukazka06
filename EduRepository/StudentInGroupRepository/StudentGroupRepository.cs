using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Linq;

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

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<StudentInGroupDbo>().Include(x => x.StudentGroup).FirstOrDefault(x => x.Id == objectId).StudentGroup.OrganizationId;
        }
    }
}
