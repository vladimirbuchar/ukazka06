using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.StudentEvaluation;

namespace EduRepository.StudentEvaluationRepository
{
    public class StudentEvaluationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentEvaluationDbo>(dbContext, memoryCache), IStudentEvaluationRepository { }
}
