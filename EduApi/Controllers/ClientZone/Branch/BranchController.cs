using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Branch.Dto;
using Services.Branch.Filter;
using Services.Branch.Service;
using Services.Branch.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Branch
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class BranchController : BaseClientZoneController
    {
        private readonly IBranchService _branchService;

        public BranchController(ILogger<BranchController> logger, IBranchService branchService, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(BranchCreateDto addBranchDto)
        {
            try
            {
                await CheckOrganizationPermition(addBranchDto.OrganizationId);
                var result = await _branchService.AddObject(addBranchDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BranchListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] BranchFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] BranchSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _branchService.GetList(
                        x => x.OrganizationId == request.ParentId && x.IsOnline == false,
                        request.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    );
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BranchDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _branchService.GetOrganizationIdByObjectId(request.Id));
                var result = await _branchService.GetDetail(request.Id, GetClientCulture());
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
        public async Task<ActionResult> Update(BranchUpdateDto updateBranchDto)
        {
            try
            {
                await CheckOrganizationPermition(await _branchService.GetOrganizationIdByObjectId(updateBranchDto.Id));
                var result = await _branchService.UpdateObject(updateBranchDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
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
                await CheckOrganizationPermition(await _branchService.GetOrganizationIdByObjectId(request.Id));
                var result = await _branchService.DeleteObject(request.Id, GetLoggedUserId());
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
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _branchService.GetOrganizationIdByObjectId(request.Id));
                var result = await _branchService.RestoreObject(request.Id, GetLoggedUserId());
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
        public async Task<ActionResult> ChangeMainBranch(BranchChangeMainBranchDto updateBranchDto)
        {
            try
            {
                await CheckOrganizationPermition(updateBranchDto.OrganizationId);
                var result = await _branchService.ChangeMainBranch(updateBranchDto.OrganizationId, updateBranchDto.BranchId, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
