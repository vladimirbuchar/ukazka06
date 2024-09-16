using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace Repository.CourseTestBankOfQuestion
{
    public class CourseTestBankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTestBankOfQuestionDbo>(dbContext, memoryCache),
            ICourseTestBankOfQuestionRepository
    { }
}
