using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTestEvaluation;

namespace EduRepository.CourseTestEvaluationRepository
{
    public class CourseTestEvaluationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTestEvaluationDbo>(dbContext, memoryCache), ICourseTestEvaluationRepository { }
}
