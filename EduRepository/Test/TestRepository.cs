using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTest;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Test
{
    public class TestRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTestDbo>(dbContext, memoryCache),
            ITestRepository
    {
        protected override IQueryable<CourseTestDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<CourseTestDbo>()
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseLessonTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTestBankOfQuestions.Where(x => x.IsDeleted == false))
                .Include(x => x.StudentTestSummaries.Where(x => x.IsDeleted == false));
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (
                await _dbContext
                    .Set<CourseTestDbo>()
                    .Include(x => x.CourseLesson)
                    .ThenInclude(x => x.CourseMaterial)
                    .FirstOrDefaultAsync(x => x.Id == objectId)
            )
                .CourseLesson
                .CourseMaterial
                .OrganizationId;
        }
    }
}
