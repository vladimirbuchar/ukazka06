using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTerm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CourseTermRepository
{
    public class CourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTermDbo>(dbContext, memoryCache), ICourseTermRepository
    {
        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseTermDbo>().Include(x => x.Course).FirstOrDefault(x => x.Id == objectId).Course.OrganizationId;
        }

        public override CourseTermDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseTermDbo>().Include(x => x.ClassRoom).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseTermDbo> GetEntities(bool deleted, Expression<Func<CourseTermDbo, bool>> predicate = null)
        {
            return [.. _dbContext
                .Set<CourseTermDbo>()
                .Where(x => x.IsDeleted == deleted)
                .Where(predicate)
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.ClassRoomTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.ClassRoom)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.BranchTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.TimeFrom)
                .Include(x => x.TimeTo)];
        }
    }
}
