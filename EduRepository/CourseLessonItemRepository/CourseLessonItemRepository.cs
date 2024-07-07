using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseLessonItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.CourseLessonItemRepository
{
    public class CourseLessonItemRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseLessonItemDbo>(dbContext, memoryCache), ICourseLessonItemRepository
    {
        public override CourseLessonItemDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLessonItemTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseLessonItemTemplate)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseLessonItemDbo> GetEntities(bool deleted, Expression<Func<CourseLessonItemDbo, bool>> predicate = null, Expression<Func<CourseLessonItemDbo, object>> orderBy = null, Expression<Func<CourseLessonItemDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLessonItemTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)

                ];
            ;
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext
                .Set<CourseLessonItemDbo>()
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseMaterial)
                .FirstOrDefault(x => x.Id == objectId).CourseLesson.CourseMaterial.OrganizationId;
        }
    }
}
