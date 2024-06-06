using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Notification;

namespace EduRepository.NotificationRepository
{
    public class NotificationRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<NotificationDbo>(dbContext, memoryCache), INotificationRepository { }
}
