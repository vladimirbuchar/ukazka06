using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTestEvaluation;
using System;
using System.Threading.Tasks;

namespace Repository.CourseTestEvaluation
{
    public class CourseTestEvaluationRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTestEvaluationDbo>(dbContext, memoryCache),
            ICourseTestEvaluationRepository
    {
        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (
                await _dbContext
                    .Set<CourseTestEvaluationDbo>()
                    .Include(x => x.CourseTest)
                    .ThenInclude(x => x.CourseLesson)
                    .ThenInclude(x => x.CourseMaterial)
                    .FirstOrDefaultAsync()
            )
                .CourseTest
                .CourseLesson
                .CourseMaterial
                .OrganizationId;
        }
    }
}
