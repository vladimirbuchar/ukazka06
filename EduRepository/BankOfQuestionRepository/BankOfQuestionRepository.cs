using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.BankOfQuestions;

namespace EduRepository.BankOfQuestionRepository
{
    public class BankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<BankOfQuestionDbo>(dbContext, memoryCache), IBankOfQuestionRepository
    {
        public override BankOfQuestionDbo GetEntity(Guid id)
        {
            return _dbContext.Set<BankOfQuestionDbo>().Where(x => x.Id == id).Include(x => x.BankOfQuestionsTranslations).ThenInclude(x => x.Culture).FirstOrDefault();
        }

        public override HashSet<BankOfQuestionDbo> GetEntities(bool deleted, Expression<Func<BankOfQuestionDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<BankOfQuestionDbo>().Where(x => x.IsDeleted == deleted).Where(predicate).Include(x => x.BankOfQuestionsTranslations).ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<BankOfQuestionDbo>().Where(x => x.Id == objectId).FirstOrDefault().OrganizationId;
        }
    }
}
