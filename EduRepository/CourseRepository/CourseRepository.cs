using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Course;

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
            return dbContext.Set<CourseDbo>().Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
