using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.OrganizationCultureRepository
{
    public class OrganizationCultureRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationCultureDbo>(dbContext, memoryCache), IOrganizationCultureRepository
    {
        public override HashSet<OrganizationCultureDbo> GetEntities(bool deleted, Expression<Func<OrganizationCultureDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<OrganizationCultureDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.Culture)];
        }

        public override OrganizationCultureDbo GetEntity(Guid id)
        {
            return _dbContext.Set<OrganizationCultureDbo>().Include(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<OrganizationCultureDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
