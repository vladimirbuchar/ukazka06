using System;
using System.Collections.Generic;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.SystemService.SendMailService.Dto;
using Services.SystemService.SendMailService.Service;

namespace EduApi.Controllers.ClientZone.SendMessage
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class SendEmailInOrganizationController : BaseClientZoneController
    {
        private readonly ISendMailService _sendMailService;

        public SendEmailInOrganizationController(
            ISendMailService sendMessageService,
            ILogger<SendEmailInOrganizationController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _sendMailService = sendMessageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SendMailListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetList([FromQuery] ListRequestDto listRequest)
        {
            try
            {
                CheckOrganizationPermition(listRequest.ParentId);
                return SendResponse(_sendMailService.GetList(listRequest.ParentId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SendMaiDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetDetail([FromQuery] DetailDto detail)
        {
            try
            {
                CheckOrganizationPermition(_sendMailService.GetOrganizationIdByObjectId(detail.Id));
                return SendResponse(_sendMailService.GetDetail(detail.Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<SendMaiDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(SendMailUpdateDto update)
        {
            try
            {
                CheckOrganizationPermition(_sendMailService.GetOrganizationIdByObjectId(update.Id));
                return SendResponse(_sendMailService.Update(update, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
