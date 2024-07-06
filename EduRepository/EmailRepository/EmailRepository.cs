using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.SendEmail;

namespace EduRepository.EmailRepository
{
    public class EmailRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<SendEmailDbo>(dbContext, memoryCache), IEmailRepository { }
}
