using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.SendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.MessageRepository
{
    public class MessageRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<MessageDbo>(dbContext, memoryCache), IMessageRepository
    {
        public override MessageDbo GetEntity(Guid id)
        {
            return _dbContext.Set<MessageDbo>()
                .Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<MessageDbo> GetEntities(bool deleted, Expression<Func<MessageDbo, bool>> predicate = null, Expression<Func<MessageDbo, object>> orderBy = null, Expression<Func<MessageDbo, object>> orderByDesc = null)
        {
            return [.. _dbContext.Set<MessageDbo>()
                .Include(x => x.SendMessageTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Where(predicate)
                .Where(x => x.IsDeleted == deleted)
                ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<MessageDbo>()
                .FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
