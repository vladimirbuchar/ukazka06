using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Notification;

namespace Repository.NotificationRepository
{
    public class NotificationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<NotificationDbo>(dbContext, memoryCache), INotificationRepository { }
}
