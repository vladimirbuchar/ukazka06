using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.AnswerRepository
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

        public override HashSet<AnswerDbo> GetEntities(bool deleted, Expression<Func<AnswerDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext
                    .Set<AnswerDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Where(predicate)
                    .Include(x => x.TestQuestionAnswerTranslations.Where(x=>x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.AnswerFileRepository.Where(x=>x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
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
