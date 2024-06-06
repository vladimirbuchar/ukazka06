using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;

namespace EduRepository.OrganizationRepository
{
    public class OrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<OrganizationDbo>(dbContext, memoryCache), IOrganizationRepository
    {
        public override OrganizationDbo GetEntity(Guid id)
        {
            return _dbContext.Set<OrganizationDbo>().Where(x => x.Id == id && x.IsDeleted == false).Include(x => x.Addresses).Include(x => x.OrganizationTranslations).FirstOrDefault();
        }

        public LicenseDbo GetLicenseByOrganization(Guid organizationId)
        {
            OrganizationDbo org = _dbContext.Set<OrganizationDbo>().Where(x => x.Id == organizationId && x.IsDeleted == false).Include(x => x.License).FirstOrDefault();
            return org.License;
        }
    }
}
