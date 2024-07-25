using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Message;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<MessageDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
