using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Link;

namespace EduRepository.CourseTestBankOfQuestionRepository
{
    public class CourseTestBankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTestBankOfQuestionDbo>(dbContext, memoryCache),
            ICourseTestBankOfQuestionRepository
    {
        public override HashSet<CourseTestBankOfQuestionDbo> GetEntities(bool deleted, Expression<Func<CourseTestBankOfQuestionDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CourseTestBankOfQuestionDbo>().Where(x => x.IsDeleted == deleted).Where(predicate)];
        }

        public override CourseTestBankOfQuestionDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CourseTestBankOfQuestionDbo>().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
