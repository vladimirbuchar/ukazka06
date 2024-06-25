using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentTestSummaryQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.StudentTestSummaryQuestionRepository
{
    public class StudentTestSummaryQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentTestSummaryQuestionDbo>(dbContext, memoryCache),
            IStudentTestSummaryQuestionRepository
    {
        public override StudentTestSummaryQuestionDbo GetEntity(Guid id)
        {
            return _dbContext.Set<StudentTestSummaryQuestionDbo>().FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<StudentTestSummaryQuestionDbo> GetEntities(bool deleted, Expression<Func<StudentTestSummaryQuestionDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<StudentTestSummaryQuestionDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)];
        }
    }
}
