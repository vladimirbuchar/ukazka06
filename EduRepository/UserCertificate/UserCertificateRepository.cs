using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.UserCertificate;

namespace Repository.UserCertificate
{
    public class UserCertificateRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<UserCertificateDbo>(dbContext, memoryCache),
            IUserCertificateRepository
    { }
}
