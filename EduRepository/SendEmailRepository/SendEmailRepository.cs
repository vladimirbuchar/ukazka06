using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.SendEmail;

namespace Repository.SendEmailRepository
{
    public class SendEmailRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<SendEmailDbo>(dbContext, memoryCache), ISendEmailRepository { }
}
