using Core.Base.Service;
using Core.Constants;
using EduRepository.NotificationRepository;
using EduRepository.OrganizationRepository;
using EduServices.Notification.Convertor;
using EduServices.Notification.Dto;
using Model.Tables.Edu.Notification;
using Model.Tables.Edu.Organization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Notification.Service
{
    public class NotificationService(INotificationRepository notificationRepository, IOrganizationRepository organizationRepository, INotificationConvertor notificationConvertor)
        : BaseService<INotificationRepository, NotificationDbo, INotificationConvertor>(notificationRepository, notificationConvertor),
            INotificationService
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public HashSet<MyNotificationListDto> GetMyNotification(Guid userId, bool onlyNew)
        {
            HashSet<NotificationDbo> notifications = [];
            notifications = [.. _repository.GetEntities(false, x => x.UserId == userId)];
            notifications = [.. notifications.OrderByDescending(x => x.AddDate)];
            if (onlyNew)
            {
                notifications = notifications.Where(x => x.IsNew).ToHashSet();
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

        public void SetIsNewNotificationToFalse(Guid userId)
        {
            HashSet<NotificationDbo> notificationDbo = _repository.GetEntities(false, x => x.UserId == userId && x.IsNew == true);
            foreach (NotificationDbo item in notificationDbo)
            {
                item.IsNew = false;
                _ = _repository.UpdateEntity(item, userId);
            }
        }
    }
}
