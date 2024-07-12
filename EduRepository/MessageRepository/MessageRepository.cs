using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Message;

namespace Repository.MessageRepository
{
    public class MessageRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<MessageDbo>(dbContext, memoryCache),
            IMessageRepository
    {
        protected override IQueryable<MessageDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<MessageDbo>().Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        protected override IQueryable<MessageDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<MessageDbo>()
                .Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.SendMessageType);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<MessageDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
