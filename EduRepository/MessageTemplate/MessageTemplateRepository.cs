using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Message;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.MessageTemplate
{
    public class MessageTemplateRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<MessageTemplateDbo>(dbContext, memoryCache),
            IMessageTemplateRepository
    {
        protected override IQueryable<MessageTemplateDbo> PrepareDetailQuery()
        {
            return _dbContext.Set<MessageTemplateDbo>().Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture);
        }

        protected override IQueryable<MessageTemplateDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<MessageTemplateDbo>()
                .Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.SendMessageType);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<MessageTemplateDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }

        protected override IQueryable<MessageTemplateDbo> PrepareDropDownQuery()
        {
            return _dbContext.Set<MessageTemplateDbo>().Include(x => x.SendMessageTranslations).ThenInclude(x => x.Culture);
        }
    }
}
