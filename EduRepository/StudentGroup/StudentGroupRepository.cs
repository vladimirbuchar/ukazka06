using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentGroup;
using System;
using System.Threading.Tasks;

namespace Repository.StudentGroup
{
    public class StudentGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentGroupDbo>(dbContext, memoryCache),
            IStudentGroupRepository
    {


        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<StudentGroupDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }


    }
}
