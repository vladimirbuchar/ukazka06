using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.ClassRoom.Dto;
using Services.ClassRoom.Filter;
using Services.ClassRoom.Service;
using Services.ClassRoom.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.ClassRoom
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class ClassRoomController : BaseClientZoneController
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(
            ILogger<ClassRoomController> logger,
            IClassRoomService classRoomService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _classRoomService = classRoomService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Create(ClassRoomCreateDto addClassRoomDto)
        {
            try
            {
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByParentId(addClassRoomDto.BranchId));
                return await SendResponse(await _classRoomService.AddObject(addClassRoomDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassRoomListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] ClassRoomFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] ClassRoomSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _classRoomService.GetList(
                        x => x.BranchId == request.ParentId && x.IsOnline == false,
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
        [ProducesResponseType(typeof(ClassRoomDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _classRoomService.GetDetail(request.Id, GetClientCulture()));
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
        public async Task<ActionResult> Update(ClassRoomUpdateDto updateClassRoomDto)
        {
            try
            {
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByObjectId(updateClassRoomDto.Id));
                return await SendResponse(await _classRoomService.UpdateObject(updateClassRoomDto, GetLoggedUserId(), GetClientCulture()));
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
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _classRoomService.DeleteObject(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByObjectId(request.Id));
                var result = await _classRoomService.RestoreObject(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassRoomListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetAllClassRoomInOrganization(
            [FromQuery] ListRequestDto list,
            [FromQuery] ClassRoomFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] ClassRoomSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(list.ParentId);
                var result = await _classRoomService.GetList(
                        x => x.Branch.OrganizationId == list.ParentId,
                        false,
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
        [ProducesResponseType(typeof(ClassRoomTimeTableDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetClassRoomTimeTable([FromQuery] ListRequestDto requestDto)
        {
            try
            {
                await CheckOrganizationPermition(await _classRoomService.GetOrganizationIdByObjectId(requestDto.ParentId));
                var result = await _classRoomService.GetClassRoomTimeTable(
                        requestDto.ParentId,
                        await _classRoomService.GetOrganizationIdByObjectId(requestDto.ParentId),
                        GetClientCulture()
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
    }
}
