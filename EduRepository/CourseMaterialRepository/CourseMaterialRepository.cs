using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseMaterial;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                .Include(x => x.CourseMaterialFileRepositories.Where(x => x.IsDeleted == false));
        }

        protected override IQueryable<CourseMaterialDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseMaterialDbo>()
                .Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<CourseMaterialDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }

        public override async Task<Guid> GetOrganizationByFileId(Guid objectId)
        {
            return (await _dbContext.Set<CourseMaterialFileRepositoryDbo>().Include(x => x.CourseMaterial)
                .FirstOrDefaultAsync(x => x.Id == objectId)).CourseMaterial.OrganizationId;
        }
    }
}
