using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentTestSummaryQuestion;

namespace EduRepository.StudentTestSummaryQuestionRepository
{
    public class StudentTestSummaryQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentTestSummaryQuestionDbo>(dbContext, memoryCache),
            IStudentTestSummaryQuestionRepository
    {

    }
}
