using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.CourseRepository
{
    public class CourseRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseDbo>(dbContext, memoryCache), ICourseRepository
    {
        public override CourseDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseDbo>()
                .Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseDbo> GetEntities(bool deleted, Expression<Func<CourseDbo, bool>> predicate = null, Expression<Func<CourseDbo, object>> orderBy = null, Expression<Func<CourseDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<CourseDbo>()
                .Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
