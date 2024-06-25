using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CourseRepository
{
    public class CourseRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseDbo>(dbContext, memoryCache), ICourseRepository
    {
        public override CourseDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseDbo>().Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseDbo> GetEntities(bool deleted, Expression<Func<CourseDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CourseDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.CourseTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
