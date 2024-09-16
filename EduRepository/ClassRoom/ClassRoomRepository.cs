using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.ClassRoom;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ClassRoom
{
    public class ClassRoomRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<ClassRoomDbo>(dbContext, memoryCache),
            IClassRoomRepository
    {
        protected override IQueryable<ClassRoomDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<ClassRoomDbo>()
                .Include(x => x.Branch)
                .Include(x => x.CourseTermDates.Where(y => y.IsDeleted == false))
                .ThenInclude(x => x.CourseTerm);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<ClassRoomDbo>().Where(x => x.Id == objectId).Include(x => x.Branch).FirstOrDefaultAsync())
                .Branch
                .OrganizationId;
        }
    }
}
