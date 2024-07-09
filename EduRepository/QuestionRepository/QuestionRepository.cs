using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Question;

namespace Repository.QuestionRepository
{
    public class QuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<QuestionDbo>(dbContext, memoryCache),
            IQuestionRepository
    {
        protected override IQueryable<QuestionDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<QuestionDbo>()
                .Include(x => x.TestQuestionTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerMode)
                .Include(x => x.QuestionMode)
                .Include(x => x.QuestionFileRepositories.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        protected override IQueryable<QuestionDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<QuestionDbo>()
                .Include(x => x.TestQuestionTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.BankOfQuestion)
                .ThenInclude(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.BankOfQuestion)
                .ThenInclude(x => x.Organization);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<QuestionDbo>().Include(x => x.BankOfQuestion).FirstOrDefault(x => x.Id == objectId).BankOfQuestion.OrganizationId;
        }
    }
}
