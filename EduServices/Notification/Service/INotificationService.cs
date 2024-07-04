using Core.Base.Service;
using Core.DataTypes;
using EduServices.Notification.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.Notification.Service
{
    public interface INotificationService : IBaseService
    {
        public HashSet<MyNotificationListDto> GetMyNotification(Guid userId, bool onlyNew);
        Result SetIsNewNotificationToFalse(Guid userId);
    }
}
