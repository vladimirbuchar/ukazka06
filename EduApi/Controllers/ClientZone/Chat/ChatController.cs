using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Note;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Chat.Dto;
using Services.Chat.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.Chat
{
    [ApiExplorerSettings(GroupName = "StudyZone")]
    public class ChatController : BaseClientZoneController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService, ILogger<NoteController> logger, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public Task<ActionResult> Create(ChatItemCreateDto addChatItemDto)
        {
            try
            {
                return SendResponse(_chatService.AddObject(addChatItemDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<ChatItemListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListRequestDto request)
        {
            try
            {
                var result = await _chatService.GetList(x => x.UserId == GetLoggedUserId() && x.CourseTermId == request.ParentId, false, GetClientCulture());
                return await SendResponse(result);
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
        public Task<ActionResult> Update(ChatItemUpdateDto updateChatItemDto)
        {
            try
            {
                return SendResponse(_chatService.UpdateObject(updateChatItemDto, GetLoggedUserId(), GetClientCulture()));
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
        public Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                return SendResponse(_chatService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
