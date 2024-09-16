using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Email;
using System.Linq;

namespace Repository.Email
{
    public class EmailRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<EmailDbo>(dbContext, memoryCache), IEmailRepository
    {
        protected override IQueryable<EmailDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<EmailDbo>().Include(x => x.EmailTranslations).ThenInclude(x => x.Culture);
        }
    }
}
