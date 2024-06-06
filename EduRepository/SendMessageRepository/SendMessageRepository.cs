using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.SendMessage;

namespace EduRepository.SendMessageRepository
{
    public class SendMessageRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<SendMessageDbo>(dbContext, memoryCache), ISendMessageRepository
    {
        public override SendMessageDbo GetEntity(Guid id)
        {
            return _dbContext.Set<SendMessageDbo>().Where(x => x.Id == id).Include(x => x.SendMessageTranslations).ThenInclude(x => x.Culture).FirstOrDefault();
        }

        public override HashSet<SendMessageDbo> GetEntities(bool deleted, Expression<Func<SendMessageDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<SendMessageDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.SendMessageTranslations).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<SendMessageDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
