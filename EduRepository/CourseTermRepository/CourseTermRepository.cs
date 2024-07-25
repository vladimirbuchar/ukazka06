using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTerm;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseTermRepository
{
    public class CourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTermDbo>(dbContext, memoryCache),
            ICourseTermRepository
    {
        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<CourseTermDbo>().Include(x => x.Course).FirstOrDefaultAsync(x => x.Id == objectId)).Course.OrganizationId;
        }

        protected override IQueryable<CourseTermDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<CourseTermDbo>().Include(x => x.ClassRoom);
        }

        protected override IQueryable<CourseTermDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseTermDbo>()
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.TimeFrom)
                .Include(x => x.TimeTo);
        }
    }
}
