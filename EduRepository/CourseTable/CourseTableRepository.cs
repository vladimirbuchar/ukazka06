using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.CourseTable;
using System;
using System.Threading.Tasks;

namespace Repository.CourseTable
{
    public class CourseTableRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<CourseTableDbo>(dbContext, memoryCache),
            ICourseTableRepository
    {

        public override Task<CourseTableDbo> UpdateEntity(CourseTableDbo entity, Guid userId)
        {
            SaveDataToCache(entity.Id.ToString(), entity.Image, DateTime.Now.AddHours(1));
            return base.UpdateEntity(entity, userId);
        }

        public override Task<CourseTableDbo> GetEntity(Guid id)
        {
            return Task.FromResult(new CourseTableDbo()
            {
                Id = id,
                Image = GetFirstDataFromCache<string>(id.ToString())
            });
        }
    }
}
