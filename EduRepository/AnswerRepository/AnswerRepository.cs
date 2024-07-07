using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.AnswerRepository
{
    public class AnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<AnswerDbo>(dbContext, memoryCache), IAnswerRepository
    {
        public override AnswerDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<AnswerDbo>()
                .Include(x => x.TestQuestionAnswerTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerFileRepository.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.TestQuestion)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<AnswerDbo> GetEntities(bool deleted, Expression<Func<AnswerDbo, bool>> predicate = null, Expression<Func<AnswerDbo, object>> orderBy = null, Expression<Func<AnswerDbo, object>> orderByDesc = null)
        {
            return
            [
                .. _dbContext
                    .Set<AnswerDbo>()
                    .Include(x => x.TestQuestionAnswerTranslations.Where(x=>x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.AnswerFileRepository.Where(x=>x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Where(predicate)
                    .Where(x => x.IsDeleted == deleted)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<AnswerDbo>()
                .Include(x => x.TestQuestion)
                .ThenInclude(x => x.BankOfQuestion)
                .FirstOrDefault(x => x.Id == objectId).TestQuestion.BankOfQuestion.OrganizationId;
        }
    }
}
