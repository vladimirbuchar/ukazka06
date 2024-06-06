using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.OrganizationStudyHour;

namespace EduRepository.OrganizationHoursRepository
{
    public class OrganizationHourRepository : BaseRepository<OrganizationStudyHourDbo>, IOrganizationStudyHourRepository
    {
        public OrganizationHourRepository(EduDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext, memoryCache) { }

        public override HashSet<OrganizationStudyHourDbo> GetEntities(bool deleted, Expression<Func<OrganizationStudyHourDbo, bool>> predicate = null)
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().Where(predicate).Where(x => x.IsDeleted == deleted).Include(x => x.ActiveFrom).Include(x => x.ActiveTo).ToHashSet();
        }

        public override OrganizationStudyHourDbo GetEntity(Guid id)
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().Where(x => x.Id == id).Include(x => x.ActiveFrom).Include(x => x.ActiveTo).FirstOrDefault();
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<OrganizationStudyHourDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
