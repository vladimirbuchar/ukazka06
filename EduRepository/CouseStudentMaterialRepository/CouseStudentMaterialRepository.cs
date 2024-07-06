using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace EduRepository.CouseStudentMaterialRepository
{
    public class CouseStudentMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CouseStudentMaterialDbo>(dbContext, memoryCache), ICouseStudentMaterialRepository { }
}
