﻿using System.Collections.Generic;
using System.Linq;
using Model.Edu.Notification;
using Services.Notification.Dto;

namespace Services.Notification.Convertor
{
    public class NotificationConvertor : INotificationConvertor
    {
        public List<MyNotificationListDto> ConvertToWebModel(List<NotificationDbo> getMyNotifications)
        {
            return getMyNotifications
                .Select(item => new MyNotificationListDto()
                {
                    Id = item.Id,
                    NotificationIdentificator = item.SystemIdentificator,
                    ObjectId = item.OrganizationId.Value,
                    Data = item.Data,
                    AddDate = item.AddDate,
                    IsNew = item.IsNew
                })
                .ToList();
        }
    }
}
