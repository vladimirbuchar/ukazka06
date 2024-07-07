using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.LicenseChange;

namespace Repository.LicenseChangeRepository
{
    public class LicenseChangeRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<LicenseChangeDbo>(dbContext, memoryCache), ILicenseChangeRepository { }
}
