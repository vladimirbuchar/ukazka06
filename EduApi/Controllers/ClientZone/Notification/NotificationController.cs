using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Notification.Dto;
using Services.Notification.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.Notification
{
    [ApiExplorerSettings(GroupName = "User")]
    public class NotificationController : BaseClientZoneController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            INotificationService notificationService,
            ILogger<NotificationController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyNotificationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public Task<ActionResult> GetMyNewNotification()
        {
            try
            {
                return SendResponse(_notificationService.GetMyNotification(GetLoggedUserId(), true));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyNotificationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public Task<ActionResult> GetMyNotification()
        {
            try
            {
                return SendResponse(_notificationService.GetMyNotification(GetLoggedUserId(), false));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> SetIsNewNotificationToFalse()
        {
            try
            {
                return await SendResponse(await _notificationService.SetIsNewNotificationToFalse(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
