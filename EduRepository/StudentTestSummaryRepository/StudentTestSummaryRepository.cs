using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentTestSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.StudentTestSummaryRepository
{
    public class StudentTestSummaryRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentTestSummaryDbo>(dbContext, memoryCache), IStudentTestSummaryRepository
    {
        public override StudentTestSummaryDbo GetEntity(Guid id)
        {
            return _dbContext.Set<StudentTestSummaryDbo>().FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<StudentTestSummaryDbo> GetEntities(bool deleted, Expression<Func<StudentTestSummaryDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<StudentTestSummaryDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)];
        }
    }
}
