using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseLesson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseLessonRepository
{
    public class CourseLessonRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseLessonDbo>(dbContext, memoryCache),
            ICourseLessonRepository
    {
        protected override IQueryable<CourseLessonDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<CourseLessonDbo>().Include(x => x.CourseLessonTranslations).ThenInclude(x => x.Culture);
        }

        protected override IQueryable<CourseLessonDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseLessonDbo>()
                .Include(x => x.CourseLessonTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext
                .Set<CourseLessonDbo>()
                .Include(x => x.CourseMaterial)
                .FirstOrDefaultAsync(x => x.Id == objectId))
                .CourseMaterial.OrganizationId;
        }


    }
}
