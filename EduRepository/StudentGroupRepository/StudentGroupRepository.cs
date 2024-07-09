using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentGroup;

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

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<StudentGroupDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
