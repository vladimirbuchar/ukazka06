using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Notification;
using System.Linq;

namespace Repository.Notification
{
    public class NotificationRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<NotificationDbo>(dbContext, memoryCache),
            INotificationRepository
    {
        protected override IQueryable<NotificationDbo> PrepareListQuery()
        {
            return _dbContext.Set<NotificationDbo>().Include(x => x.Organization).Include(x => x.NotificationType);
        }

    }
}
