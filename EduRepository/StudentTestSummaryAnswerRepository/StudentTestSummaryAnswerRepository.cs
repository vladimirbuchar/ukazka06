using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentTestSummaryAnswer;

namespace EduRepository.StudentTestSummaryAnswerRepository
{
    public class StudentTestSummaryAnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentTestSummaryAnswerDbo>(dbContext, memoryCache),
            IStudentTestSummaryAnswerRepository { }
}
