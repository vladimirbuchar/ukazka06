using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.TestQuestion;

namespace EduRepository.QuestionRepository
{
    public class QuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<QuestionDbo>(dbContext, memoryCache), IQuestionRepository
    {
        public override QuestionDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<QuestionDbo>()
                .Where(x => x.Id == id)
                .Include(x => x.TestQuestionTranslation)
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerMode)
                .Include(x => x.QuestionMode)
                .Include(x => x.QuestionFileRepositories)
                .ThenInclude(x => x.Culture)
                .FirstOrDefault();
        }

        public override HashSet<QuestionDbo> GetEntities(bool deleted, Expression<Func<QuestionDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext
                    .Set<QuestionDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Where(predicate)
                    .Include(x => x.TestQuestionTranslation)
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.BankOfQuestion)
                    .ThenInclude(x => x.BankOfQuestionsTranslations)
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.BankOfQuestion)
                    .ThenInclude(x => x.Organization)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<QuestionDbo>().Where(x => x.Id == objectId).Include(x => x.BankOfQuestion).FirstOrDefault().BankOfQuestion.OrganizationId;
        }
    }
}
