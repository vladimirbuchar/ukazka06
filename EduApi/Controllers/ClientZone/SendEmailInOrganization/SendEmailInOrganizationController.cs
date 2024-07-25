using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.SystemService.SendMailService.Dto;
using Services.SystemService.SendMailService.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult> List([FromQuery] ListRequestDto listRequest)
        {
            try
            {
                await CheckOrganizationPermition(listRequest.ParentId);
                return await SendResponse(_sendMailService.GetList(listRequest.ParentId));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SendMaiDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailDto detail)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMailService.GetOrganizationIdByObjectId(detail.Id));
                return await SendResponse(await _sendMailService.GetDetail(detail.Id));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<SendMaiDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(SendMailUpdateDto update)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMailService.GetOrganizationIdByObjectId(update.Id));
                return await SendResponse(await _sendMailService.Update(update, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
