using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.CourseMaterialRepository
{
    public class CourseMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseMaterialDbo>(dbContext, memoryCache), ICourseMaterialRepository
    {
        public override CourseMaterialDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseMaterialDbo>()
                .Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseMaterialFileRepositories)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseMaterialDbo> GetEntities(bool deleted, Expression<Func<CourseMaterialDbo, bool>> predicate = null, Expression<Func<CourseMaterialDbo, object>> orderBy = null, Expression<Func<CourseMaterialDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<CourseMaterialDbo>()
                .Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ]
                ;
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseMaterialDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }

    }
}
