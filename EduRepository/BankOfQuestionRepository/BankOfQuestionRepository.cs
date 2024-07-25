using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.BankOfQuestions;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (await _dbContext.Set<BankOfQuestionDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId;
        }
    }
}
