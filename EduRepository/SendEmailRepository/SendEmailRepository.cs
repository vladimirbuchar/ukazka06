using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.SendEmail;

namespace Repository.SendEmailRepository
{
    public class SendEmailRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<SendEmailDbo>(dbContext, memoryCache),
            ISendEmailRepository
    {
        protected override IQueryable<SendEmailDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<SendEmailDbo>().Include(x => x.SendEmailAttachments);
        }

        protected override IQueryable<SendEmailDbo> PrepareListQuery()
        {
            return _dbContext.Set<SendEmailDbo>().Include(x => x.SendEmailAttachments);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<SendEmailDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId.Value;
        }
    }
}
