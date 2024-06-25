using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTest;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.TestRepository
{
    public class TestRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTestDbo>(dbContext, memoryCache), ITestRepository
    {
        public override CourseTestDbo GetEntity(bool deleted, Expression<Func<CourseTestDbo, bool>> predicate = null)
        {
            return _dbContext
                .Set<CourseTestDbo>()
                .Where(x => x.IsDeleted == deleted)
                .Where(predicate)
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseLessonTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTestBankOfQuestions.Where(x => x.IsDeleted == false))
                .FirstOrDefault();
        }
    }
}
