using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Answer;

namespace EduRepository.AnswerRepository
{
    public class AnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<AnswerDbo>(dbContext, memoryCache), IAnswerRepository
    {
        public override AnswerDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<AnswerDbo>()
                .Where(x => x.Id == id)
                .Include(x => x.TestQuestionAnswerTranslations)
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerFileRepository)
                .ThenInclude(x => x.Culture)
                .Include(x => x.TestQuestion)
                .FirstOrDefault();
        }

        public override HashSet<AnswerDbo> GetEntities(bool deleted, Expression<Func<AnswerDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext
                    .Set<AnswerDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Where(predicate)
                    .Include(x => x.TestQuestionAnswerTranslations)
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.AnswerFileRepository)
                    .ThenInclude(x => x.Culture)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<AnswerDbo>().Where(x => x.Id == objectId).Include(x => x.TestQuestion).ThenInclude(x => x.BankOfQuestion).FirstOrDefault().TestQuestion.BankOfQuestion.OrganizationId;
        }
    }
}
