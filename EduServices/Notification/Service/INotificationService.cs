using Core.Base.Service;
using Core.DataTypes;
using Services.Notification.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Notification.Service
{
    public interface INotificationService : IBaseService
    {
        Task<List<MyNotificationListDto>> GetMyNotification(Guid userId, bool onlyNew);
        Task<Result> SetIsNewNotificationToFalse(Guid userId);
    }
}
