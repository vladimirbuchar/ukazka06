using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Answer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Answer
{
    public class AnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<AnswerDbo>(dbContext, memoryCache),
            IAnswerRepository
    {
        protected override IQueryable<AnswerDbo> PrepareDetailQuery()
        {
            return _dbContext
                .Set<AnswerDbo>()
                .Include(x => x.TestQuestionAnswerTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerFileRepository.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.Question);
        }

        protected override IQueryable<AnswerDbo> PrepareListQuery()
        {
            return _dbContext
                .Set<AnswerDbo>()
                .Include(x => x.TestQuestionAnswerTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerFileRepository.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            return (
                await _dbContext
                    .Set<AnswerDbo>()
                    .Include(x => x.Question)
                    .ThenInclude(x => x.BankOfQuestion)
                    .FirstOrDefaultAsync(x => x.Id == objectId)
            )
                .Question
                .BankOfQuestion
                .OrganizationId;
        }
    }
}
