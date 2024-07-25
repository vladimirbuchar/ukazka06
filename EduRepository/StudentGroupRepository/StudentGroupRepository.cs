using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentGroup;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.StudentGroupRepository
{
    public class StudentGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentGroupDbo>(dbContext, memoryCache),
            IStudentGroupRepository
    {
        protected override IQueryable<StudentGroupDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<StudentGroupDbo>()
                .Include(x => x.StudentGroupTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        protected override IQueryable<StudentGroupDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<StudentGroupDbo>()
                .Include(x => x.StudentGroupTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<StudentGroupDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
