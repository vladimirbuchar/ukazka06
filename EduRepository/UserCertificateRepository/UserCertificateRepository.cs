using Core.Base.Repository;
using EduRepository.UserCertificateRepository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.UserCertificate;

namespace EduRepository.UserInOrganizationRepository
{
    public class UserCertificateRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<UserCertificateDbo>(dbContext, memoryCache), IUserCertificateRepository { }
}
