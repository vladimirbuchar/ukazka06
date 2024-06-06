using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.Notification.Dto;

namespace EduServices.Notification.Service
{
    public interface INotificationService : IBaseService
    {
        public HashSet<MyNotificationListDto> GetMyNotification(Guid userId, bool onlyNew);
        void SetIsNewNotificationToFalse(Guid userId);
    }
}
