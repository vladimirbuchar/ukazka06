using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.BankOfQuestions;

namespace Repository.BankOfQuestionRepository
{
    public class BankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<BankOfQuestionDbo>(dbContext, memoryCache), IBankOfQuestionRepository
    {
        public override BankOfQuestionDbo GetEntity(Guid id)
        {
            return _dbContext.Set<BankOfQuestionDbo>().Include(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false)).ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<BankOfQuestionDbo> GetEntities(
            bool deleted,
            Expression<Func<BankOfQuestionDbo, bool>> predicate = null,
            Expression<Func<BankOfQuestionDbo, object>> orderBy = null,
            Expression<Func<BankOfQuestionDbo, object>> orderByDesc = null
        )
        {
            return
            [
                .. _dbContext
                    .Set<BankOfQuestionDbo>()
                    .Include(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Where(predicate)
                    .Where(x => x.IsDeleted == deleted)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<BankOfQuestionDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
