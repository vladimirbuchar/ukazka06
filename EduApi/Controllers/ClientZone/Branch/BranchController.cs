using System;
using System.Collections.Generic;
using System.Web.Helpers;
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
        public ActionResult Create(BranchCreateDto addBranchDto)
        {
            try
            {
                CheckOrganizationPermition(addBranchDto.OrganizationId);
                return SendResponse(_branchService.AddObject(addBranchDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BranchListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] BranchFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] BranchSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                CheckOrganizationPermition(request.ParentId);
                return SendResponse(
                    _branchService.GetList(
                        x => x.OrganizationId == request.ParentId && x.IsOnline == false,
                        request.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    )
                );
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BranchDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_branchService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_branchService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(BranchUpdateDto updateBranchDto)
        {
            try
            {
                CheckOrganizationPermition(_branchService.GetOrganizationIdByObjectId(updateBranchDto.Id));
                return SendResponse(_branchService.UpdateObject(updateBranchDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_branchService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_branchService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_branchService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_branchService.RestoreObject(request.Id, GetLoggedUserId()));
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
        public ActionResult ChangeMainBranch(BranchChangeMainBranchDto updateBranchDto)
        {
            try
            {
                CheckOrganizationPermition(updateBranchDto.OrganizationId);
                return SendResponse(_branchService.ChangeMainBranch(updateBranchDto.OrganizationId, updateBranchDto.BranchId, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
