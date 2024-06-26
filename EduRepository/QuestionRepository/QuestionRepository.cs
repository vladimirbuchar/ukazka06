﻿using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.TestQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.QuestionRepository
{
    public class QuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<QuestionDbo>(dbContext, memoryCache), IQuestionRepository
    {
        public override QuestionDbo GetEntity(Guid id)
        {
            return _dbContext
                .Set<QuestionDbo>()
                .Include(x => x.TestQuestionTranslation.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.AnswerMode)
                .Include(x => x.QuestionMode)
                .Include(x => x.QuestionFileRepositories.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<QuestionDbo> GetEntities(bool deleted, Expression<Func<QuestionDbo, bool>> predicate = null)
        {
            return
            [
                .. _dbContext
                    .Set<QuestionDbo>()
                    .Where(x => x.IsDeleted == deleted)
                    .Where(predicate)
                    .Include(x => x.TestQuestionTranslation.Where(x => x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.BankOfQuestion)
                    .ThenInclude(x => x.BankOfQuestionsTranslations.Where(x => x.IsDeleted == false))
                    .ThenInclude(x => x.Culture)
                    .Include(x => x.BankOfQuestion)
                    .ThenInclude(x => x.Organization)
            ];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<QuestionDbo>().Include(x => x.BankOfQuestion).FirstOrDefault(x => x.Id == objectId).BankOfQuestion.OrganizationId;
        }
    }
}
