using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Message.Dto;
using Services.Message.Filter;
using Services.Message.Service;
using Services.Message.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.SendMessage
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class MessageController : BaseClientZoneController
    {
        private readonly IMessageService _sendMessageService;

        public MessageController(
            IMessageService sendMessageService,
            ILogger<MessageController> logger,
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
        public async Task<ActionResult> Create(MessageCreateDto addSendMessageDto)
        {
            try
            {
                await CheckOrganizationPermition(addSendMessageDto.OrganizationId);
                return await SendResponse(await _sendMessageService.AddObject(addSendMessageDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] MessageFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] MessageSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _sendMessageService.GetList(
                        x => x.OrganizationId == request.ParentId,
                        request.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    );
                return await SendResponse(
                    result
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(MessageDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _sendMessageService.GetDetail(request.Id, GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(MessageUpdateDto updateSendMessageDto)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMessageService.GetOrganizationIdByObjectId(updateSendMessageDto.Id));
                return await SendResponse(await _sendMessageService.UpdateObject(updateSendMessageDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(_sendMessageService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _sendMessageService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _sendMessageService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
