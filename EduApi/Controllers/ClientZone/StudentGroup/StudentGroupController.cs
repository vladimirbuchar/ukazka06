using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.StudentInGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Filter;
using Services.StudentGroup.Service;
using Services.StudentGroup.Sort;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.StudentGroup
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class StudentGroupController : BaseClientZoneController
    {
        private readonly IStudentGroupService _studentGroupService;

        public StudentGroupController(
            IStudentGroupService studentGroupService,
            ILogger<StudentInGroupController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _studentGroupService = studentGroupService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(StudentGroupCreateDto addStudentGroupDto)
        {
            try
            {
                await CheckOrganizationPermition(addStudentGroupDto.OrganizationId);
                return await SendResponse(await _studentGroupService.AddObject(addStudentGroupDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentGroupInOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto reuest,
            [FromQuery] StudentGroupFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] StudentGroupSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(reuest.ParentId);
                var result = await _studentGroupService.GetList(
                        x => x.OrganizationId == reuest.ParentId,
                        reuest.IsDeleted,
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
        [ProducesResponseType(typeof(StudentGroupDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _studentGroupService.GetDetail(request.Id, GetClientCulture()));
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
        public async Task<ActionResult> Update(StudentGroupUpdateDto updateStudentGroupDto)
        {
            try
            {
                await CheckOrganizationPermition(await _studentGroupService.GetOrganizationIdByObjectId(updateStudentGroupDto.Id));
                return await SendResponse(await _studentGroupService.UpdateObject(updateStudentGroupDto, GetLoggedUserId(), GetClientCulture()));
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
                await CheckOrganizationPermition(await _studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _studentGroupService.DeleteObject(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _studentGroupService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
