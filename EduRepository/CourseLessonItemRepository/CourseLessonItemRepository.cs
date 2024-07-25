using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseLessonItem;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseLessonItemRepository
{
    public class CourseLessonItemRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseLessonItemDbo>(dbContext, memoryCache),
            ICourseLessonItemRepository
    {
        protected override IQueryable<CourseLessonItemDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLessonItemTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseLessonItemTemplate);
        }

        protected override IQueryable<CourseLessonItemDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLessonItemTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseMaterial)
                .FirstOrDefaultAsync(x => x.Id == objectId))
                .CourseLesson.CourseMaterial.OrganizationId;
        }

        public override async Task<Guid> GetOrganizationByFileId(Guid objectId)
        {
            return (await _dbContext
                .Set<CourseLessonItemFileRepositoryDbo>()
                .Include(x => x.CourseLessonItem)
                .ThenInclude(x => x.CourseLesson)
                .ThenInclude(x => x.CourseMaterial)
                .FirstOrDefaultAsync(x => x.Id == objectId))
                .CourseLessonItem.CourseLesson.CourseMaterial.OrganizationId;
        }
    }
}
