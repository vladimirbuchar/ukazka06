using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Link;

namespace Repository.CouseStudentMaterial
{
    public class CouseStudentMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseStudentMaterialDbo>(dbContext, memoryCache),
            ICourseStudentMaterialRepository
    { }
}
