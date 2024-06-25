using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CourseMaterialRepository
{
    public class CourseMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseMaterialDbo>(dbContext, memoryCache), ICourseMaterialRepository
    {
        public override CourseMaterialDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseMaterialDbo>().Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CourseMaterialDbo> GetEntities(bool deleted, Expression<Func<CourseMaterialDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CourseMaterialDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.CourseMaterialTranslation.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CourseMaterialDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }

        public HashSet<CourseMaterialFileRepositoryDbo> GetFiles(Guid id)
        {
            return
            [
                .. _dbContext.Set<CourseMaterialDbo>().Include(x => x.CourseMaterialFileRepositories.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id).CourseMaterialFileRepositories
            ];
        }
    }
}
