using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.StudentEvaluation;

namespace Repository.StudentEvaluationRepository
{
    public class StudentEvaluationRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<StudentEvaluationDbo>(dbContext, memoryCache),
            IStudentEvaluationRepository { }
}
