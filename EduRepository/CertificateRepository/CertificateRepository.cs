using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Certificate;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<CertificateDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
