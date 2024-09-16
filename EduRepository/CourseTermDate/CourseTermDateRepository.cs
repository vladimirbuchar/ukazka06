using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTermDate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseTermDate
{
    public class CourseTermDateRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTermDateDbo>(dbContext, memoryCache),
            ICourseTermDateRepository
    {
        protected override IQueryable<CourseTermDateDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseTermDateDbo>()
                .Include(x => x.TimeFrom)
                .Include(x => x.TimeTo)
                .Include(x => x.ClassRoom)
                .Include(x => x.UserInOrganization)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Person)
                .Include(x => x.CourseTerm);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (
                await _dbContext
                    .Set<CourseTermDateDbo>()
                    .Include(x => x.CourseTerm)
                    .ThenInclude(x => x.Course)
                    .FirstOrDefaultAsync(x => x.Id == objectId)
            )
                .CourseTerm
                .Course
                .OrganizationId;
        }
    }
}
