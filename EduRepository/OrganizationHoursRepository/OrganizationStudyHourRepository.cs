using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.OrganizationStudyHour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.OrganizationHoursRepository
{
    public class OrganizationStudyHourRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationStudyHourDbo>(dbContext, memoryCache), IOrganizationStudyHourRepository
    {
        public override HashSet<OrganizationStudyHourDbo> GetEntities(bool deleted, Expression<Func<OrganizationStudyHourDbo, bool>> predicate = null, Expression<Func<OrganizationStudyHourDbo, object>> orderBy = null, Expression<Func<OrganizationStudyHourDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<OrganizationStudyHourDbo>()
                .Include(x => x.ActiveFrom)
                .Include(x => x.ActiveTo)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ];
        }

        public override OrganizationStudyHourDbo GetEntity(Guid id)
        {
            return _dbContext.Set<OrganizationStudyHourDbo>()
                .Include(x => x.ActiveFrom)
                .Include(x => x.ActiveTo)
                .FirstOrDefault(x => x.Id == id);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
