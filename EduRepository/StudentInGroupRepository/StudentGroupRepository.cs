using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace EduRepository.StudentInGroupRepository
{
    public class StudentInGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<StudentInGroupDbo>(dbContext, memoryCache), IStudentInGroupRepository { }
}
