using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.LicenseChange;

namespace EduRepository.LicenseChangeRepository
{
    public class LicenseChangeRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<LicenseChangeDbo>(dbContext, memoryCache), ILicenseChangeRepository { }
}
