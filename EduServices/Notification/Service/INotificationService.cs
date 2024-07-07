using System;
using System.Collections.Generic;
using Core.Base.Service;
using Core.DataTypes;
using Services.Notification.Dto;

namespace Services.Notification.Service
{
    public interface INotificationService : IBaseService
    {
        public HashSet<MyNotificationListDto> GetMyNotification(Guid userId, bool onlyNew);
        Result SetIsNewNotificationToFalse(Guid userId);
    }
}
