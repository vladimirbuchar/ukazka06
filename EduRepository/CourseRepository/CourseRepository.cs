using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Course;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseRepository
{
    public class CourseRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseDbo>(dbContext, memoryCache),
            ICourseRepository
    {
        protected override IQueryable<CourseDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<CourseDbo>().Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        protected override IQueryable<CourseDbo> PrepareListQuery()
        {
            return dbContext.Set<CourseDbo>()
                .Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseStatus)
                .Include(x => x.CourseType)
                .Include(x => x.SendMessage)
                        .ThenInclude(x => x.SendMessageTranslations)
                    .ThenInclude(x => x.Culture)
                .Include(x => x.Certificate)
                    .ThenInclude(x => x.CertificateTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseMaterial)
                .ThenInclude(x => x.CourseMaterialTranslation)
                .ThenInclude(x => x.Culture);



        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<CourseDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
