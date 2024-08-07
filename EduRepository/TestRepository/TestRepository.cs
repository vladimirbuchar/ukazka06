﻿using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTest;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.TestRepository
{
    public class TestRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTestDbo>(dbContext, memoryCache),
            ITestRepository
    {
        public override async Task<CourseTestDbo> GetEntity(bool deleted, Expression<Func<CourseTestDbo, bool>> predicate = null)
        {
            return await _dbContext
                .Set<CourseTestDbo>()
                .Include(x => x.CourseLesson)
                .ThenInclude(x => x.CourseLessonTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)
                .Include(x => x.CourseTestBankOfQuestions.Where(x => x.IsDeleted == false))
                .Where(x => x.IsDeleted == deleted)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
