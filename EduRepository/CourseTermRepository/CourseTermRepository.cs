using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTerm;

namespace EduRepository.CourseTermRepository
{
    public class CourseTermRepository : BaseRepository<CourseTermDbo>, ICourseTermRepository
    {
        public CourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseTermDbo>().Where(x => x.Id == objectId).Include(x => x.Course).FirstOrDefault().Course.OrganizationId;
        }

        public override CourseTermDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseTermDbo>().Where(x => x.Id == id).Include(x => x.ClassRoom).FirstOrDefault();
        }

        public override HashSet<CourseTermDbo> GetEntities(bool deleted, Expression<Func<CourseTermDbo, bool>> predicate = null)
        {
            return _dbContext
                .Set<CourseTermDbo>()
                .Where(x => x.IsDeleted == deleted)
                .Where(predicate)
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.ClassRoomTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.TimeFrom)
                .Include(x => x.TimeTo)
                .ToHashSet();
        }
    }
}
