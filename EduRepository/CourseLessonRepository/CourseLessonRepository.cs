using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CourseLessonRepository
{
    public class CourseLessonRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseLessonDbo>(dbContext, memoryCache), ICourseLessonRepository
    {
        public override CourseLessonDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseLessonDbo>().Include(x => x.CourseLessonTranslations).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseLessonDbo> GetEntities(bool deleted, Expression<Func<CourseLessonDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext.Set<CourseLessonDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.CourseLessonTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).OrderBy(x => x.Position)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseLessonDbo>().Include(x => x.CourseMaterial).FirstOrDefault(x => x.Id == objectId).CourseMaterial.OrganizationId;
        }
    }
}
