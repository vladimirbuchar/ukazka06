using Core.Base.Controller;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Model;
using UserService.Notification.NotificationList.Command;
using UserService.Notification.NotificationList.Dto;
using UserService.Notification.NotificationUpdate.Command;
using UserService.Notification.NotificationUpdate.Dto;

namespace UserApi.Controllers.Notification
{
    [ApiExplorerSettings(GroupName = "User")]
    public class NotificationController : BaseClientZoneController
    {
        private readonly INotificationListService _getMyNotificationService;
        private readonly INotificationUpdateService _setIsNewNotificationToFalseService;

        public NotificationController(
            ILogger<NotificationController> logger,
            EduDbContext organizationRoleService,
            INotificationListService getMyNotificationService,
            INotificationUpdateService setIsNewNotificationToFalseService
        )
            : base(logger, organizationRoleService)
        {
            _getMyNotificationService = getMyNotificationService;
            _setIsNewNotificationToFalseService = setIsNewNotificationToFalseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyNewNotification()
        {
            try
            {
                return await SendResponse(
                    await _getMyNotificationService.Execute(x => x.UserId == GetLoggedUserId() && x.IsNew == true, false, [GetClientCulture()])
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyNotification()
        {
            try
            {
                return await SendResponse(await _getMyNotificationService.Execute(x => x.UserId == GetLoggedUserId(), false, [GetClientCulture()]));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
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
                return await SendResponse(
                    await _setIsNewNotificationToFalseService.Execute(
                        new NotificationUpdateDto() { IsNew = false },
                        GetLoggedUserId(),
                        GetClientCulture(),
                        null,
                        x => x.UserId == GetLoggedUserId() && x.IsNew == true
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
