using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentTestSummaryAnswer;

namespace Repository.StudentTestSummaryAnswer
{
    public class StudentTestSummaryAnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentTestSummaryAnswerDbo>(dbContext, memoryCache),
            IStudentTestSummaryAnswerRepository
    { }
}
