using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Organization;

namespace Repository.OrganizationRepository
{
    public class OrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationDbo>(dbContext, memoryCache), IOrganizationRepository
    {
        public override OrganizationDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<OrganizationDbo>()
                .Include(x => x.Addresses.Where(x => x.IsDeleted == false))
                .Include(x => x.OrganizationTranslations.Where(x => x.IsDeleted == false))
                .Include(x => x.OrganizationFileRepositories.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
