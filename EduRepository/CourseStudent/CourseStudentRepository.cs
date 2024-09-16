using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CourseStudent
{
    public class CourseStudentRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseStudentDbo>(dbContext, memoryCache),
            ICourseStudentRepository
    {
        protected override IQueryable<CourseStudentDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CourseStudentDbo>()
                .Include(x => x.UserInOrganization)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Person)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.Organization)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeFrom)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeTo);
        }

        public async Task<List<CourseStudentDbo>> GetStudentCourse(Guid userId, bool hideFinishCourse)
        {
            List<CourseStudentDbo> courses = await _dbContext
                .Set<CourseStudentDbo>()
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.Organization)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeFrom)
                .Include(x => x.CourseTerm)
                .ThenInclude(x => x.TimeTo)
                .Include(x => x.UserInOrganization)
                .Where(x => x.UserInOrganization.UserId == userId)
                .ToListAsync();

            if (hideFinishCourse)
            {
                courses = courses.Where(x => x.CourseFinish == false).ToList();
            }
            return [.. courses.OrderBy(x => x.CourseFinish)];
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (
                await _dbContext
                    .Set<CourseStudentDbo>()
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
