using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseLessonItem;

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

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseMaterial)
                .FirstOrDefault(x => x.Id == objectId)
                .CourseLesson.CourseMaterial.OrganizationId;
        }
    }
}
