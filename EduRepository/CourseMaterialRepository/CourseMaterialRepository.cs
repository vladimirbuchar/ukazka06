using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseMaterial;

namespace Repository.CourseMaterialRepository
{
    public class CourseMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseMaterialDbo>(dbContext, memoryCache),
            ICourseMaterialRepository
    {
        protected override IQueryable<CourseMaterialDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<CourseMaterialDbo>()
                .Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseMaterialFileRepositories);
        }

        protected override IQueryable<CourseMaterialDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseMaterialDbo>()
                .Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseMaterialDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
