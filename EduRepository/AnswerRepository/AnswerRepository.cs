using System;
using System.Linq;
using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Answer;

namespace Repository.AnswerRepository
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
                .Include(x => x.TestQuestion);
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

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext
                .Set<AnswerDbo>()
                .Include(x => x.TestQuestion)
                .ThenInclude(x => x.BankOfQuestion)
                .FirstOrDefault(x => x.Id == objectId)
                .TestQuestion.BankOfQuestion.OrganizationId;
        }
    }
}
