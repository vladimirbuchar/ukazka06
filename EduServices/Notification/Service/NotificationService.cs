﻿using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Notification;
using Model.Edu.Organization;
using Repository.NotificationRepository;
using Repository.OrganizationRepository;
using Services.Notification.Convertor;
using Services.Notification.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<MyNotificationListDto>> GetMyNotification(Guid userId, bool onlyNew)
        {
            List<NotificationDbo> notifications = [];
            notifications = [.. await _repository.GetEntities(false, x => x.UserId == userId, null, [
                new Core.Base.Sort.BaseSort<NotificationDbo>(){
                    Sort = x => x.AddDate
                }
            ])];
            if (onlyNew)
            {
                notifications = notifications.Where(x => x.IsNew).ToList();
            }
            foreach (NotificationDbo item in notifications)
            {
                if (item.SystemIdentificator == NotificationType.INVITE_TO_ORGANIZATION)
                {
                    OrganizationDbo getOrganizationDetail = await _organizationRepository.GetEntity(false, x => x.Id == item.OrganizationId);
                    item.Data.Add("{organizationName}", getOrganizationDetail.Name);
                }
            }
            return _convertor.ConvertToWebModel(notifications);
        }

        public async Task<Result> SetIsNewNotificationToFalse(Guid userId)
        {
            List<NotificationDbo> notificationDbo = await _repository.GetEntities(false, x => x.UserId == userId && x.IsNew == true);
            foreach (NotificationDbo item in notificationDbo)
            {
                item.IsNew = false;
                _ = await _repository.UpdateEntity(item, userId);
            }
            return new Result();
        }
    }
}
