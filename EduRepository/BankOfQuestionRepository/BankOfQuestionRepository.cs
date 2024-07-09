using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.BankOfQuestions;

namespace Repository.BankOfQuestionRepository
{
    public class BankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<BankOfQuestionDbo>(dbContext, memoryCache),
            IBankOfQuestionRepository
    {
        protected override IQueryable<BankOfQuestionDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<BankOfQuestionDbo>()
                .Include(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        protected override IQueryable<BankOfQuestionDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<BankOfQuestionDbo>()
                .Include(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<BankOfQuestionDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
