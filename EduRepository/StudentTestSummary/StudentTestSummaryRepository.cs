using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentTestSummary;

namespace Repository.StudentTestSummary
{
    public class StudentTestSummaryRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentTestSummaryDbo>(dbContext, memoryCache),
            IStudentTestSummaryRepository
    { }
}
