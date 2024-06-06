using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseLesson;

namespace EduRepository.CourseLessonRepository
{
    public class CourseLessonRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseLessonDbo>(dbContext, memoryCache), ICourseLessonRepository
    {
        public override CourseLessonDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseLessonDbo>().Where(x => x.Id == id).Include(x => x.CourseLessonTranslations).ThenInclude(x => x.Culture).FirstOrDefault();
        }

        public override HashSet<CourseLessonDbo> GetEntities(bool deleted, Expression<Func<CourseLessonDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext.Set<CourseLessonDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.CourseLessonTranslations).ThenInclude(x => x.Culture).OrderBy(x => x.Position)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseLessonDbo>().Where(x => x.Id == objectId).Include(x => x.CourseMaterial).FirstOrDefault().CourseMaterial.OrganizationId;
        }
    }
}
