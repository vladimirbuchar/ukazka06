using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTermDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CourseTermDateRepository
{
    public class CourseTermDateRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTermDateDbo>(dbContext, memoryCache), ICourseTermDateRepository
    {
        public override CourseTermDateDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseTermDateDbo>().FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseTermDateDbo> GetEntities(bool deleted, Expression<Func<CourseTermDateDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CourseTermDateDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)];
        }
    }
}
