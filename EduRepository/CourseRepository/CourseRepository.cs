using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Course;

namespace EduRepository.CourseRepository
{
    public class CourseRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseDbo>(dbContext, memoryCache), ICourseRepository
    {
        public override CourseDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseDbo>().Where(x => x.Id == id).Include(x => x.CourseTranslations).ThenInclude(x => x.Culture).FirstOrDefault();
        }

        public override HashSet<CourseDbo> GetEntities(bool deleted, Expression<Func<CourseDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CourseDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.CourseTranslations).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
