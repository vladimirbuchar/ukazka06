﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Notification;
using Model.Edu.Organization;
using Repository.NotificationRepository;
using Repository.OrganizationRepository;
using Services.Notification.Convertor;
using Services.Notification.Dto;

namespace Services.Notification.Service
{
    public class NotificationService(
        INotificationRepository notificationRepository,
        IOrganizationRepository organizationRepository,
        INotificationConvertor notificationConvertor
    )
        : BaseService<INotificationRepository, NotificationDbo, INotificationConvertor>(notificationRepository, notificationConvertor),
            INotificationService
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public List<MyNotificationListDto> GetMyNotification(Guid userId, bool onlyNew)
        {
            List<NotificationDbo> notifications = [];
            notifications = [.. _repository.GetEntities(false, x => x.UserId == userId, null, x => x.AddDate).Result];
            if (onlyNew)
            {
                notifications = notifications.Where(x => x.IsNew).ToList();
            }
            foreach (NotificationDbo item in notifications)
            {
                if (item.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION)
                {
                    OrganizationDbo getOrganizationDetail = _organizationRepository.GetEntity(false, x => x.Id == item.OrganizationId);
                    item.Data.Add("{organizationName}", getOrganizationDetail.Name);
                }
            }
            return _convertor.ConvertToWebModel(notifications);
        }

        public Result SetIsNewNotificationToFalse(Guid userId)
        {
            List<NotificationDbo> notificationDbo = _repository.GetEntities(false, x => x.UserId == userId && x.IsNew == true).Result;
            foreach (NotificationDbo item in notificationDbo)
            {
                item.IsNew = false;
                _ = _repository.UpdateEntity(item, userId);
            }
            return new Result();
        }
    }
}
