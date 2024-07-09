using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Certificate;

namespace Repository.CertificateRepository
{
    public class CertificateRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CertificateDbo>(dbContext, memoryCache),
            ICertificateRepository
    {
        protected override IQueryable<CertificateDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<CertificateDbo>()
                .Include(x => x.CertificateTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        protected override IQueryable<CertificateDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<CertificateDbo>()
                .Include(x => x.CertificateTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CertificateDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
