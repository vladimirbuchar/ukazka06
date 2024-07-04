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

    }
}
