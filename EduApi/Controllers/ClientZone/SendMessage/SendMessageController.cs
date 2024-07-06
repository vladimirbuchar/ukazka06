using Core.Base.Dto;
using Core.Constants;
using Core.DataTypes;
using EduServices.OrganizationRole.Service;
using EduServices.SendMessage.Dto;
using EduServices.SendMessage.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.SendMessage
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class SendMessageController : BaseClientZoneController
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(
            ISendMessageService sendMessageService,
            ILogger<SendMessageController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(SendMessageCreateDto addSendMessageDto)
        {
            try
            {
                CheckOrganizationPermition(addSendMessageDto.OrganizationId);
                return SendResponse(_sendMessageService.AddObject(addSendMessageDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SendMessageListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(request.ParentId);
                return SendResponse(_sendMessageService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(SendMessageDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_sendMessageService.GetDetail(request.Id, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(SendMessageUpdateDto updateSendMessageDto)
        {
            try
            {
                CheckOrganizationPermition(_sendMessageService.GetOrganizationIdByObjectId(updateSendMessageDto.Id));
                return SendResponse(_sendMessageService.UpdateObject(updateSendMessageDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Delete([FromQuery] DeleteDto request)
        {
            try
            {
                CheckOrganizationPermition(_sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_sendMessageService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Restore([FromQuery] RestoreDto request)
        {
            try
            {
                CheckOrganizationPermition(_sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_sendMessageService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SendMessageListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetSendMessageInOrganizationEmail([FromQuery] Guid organizationId)
        {
            try
            {
                CheckOrganizationPermition(organizationId);
                return SendResponse(_sendMessageService.GetList(x => x.OrganizationId == organizationId && x.SystemIdentificator == SendMessageType.EMAIL, false));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
