using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentInGroup.Dto;
using Services.StudentInGroup.Filter;
using Services.StudentInGroup.Service;
using Services.StudentInGroup.Sort;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.StudentInGroup;

[ApiExplorerSettings(GroupName = "Organization")]
public class StudentInGroupController : BaseClientZoneController
{
    private readonly IStudentInGroupService _studentInGroupService;

    public StudentInGroupController(
        IStudentInGroupService studentInGroupService,
        ILogger<StudentInGroupController> logger,
        IOrganizationRoleService organizationRoleService
    )
        : base(logger, organizationRoleService)
    {
        _studentInGroupService = studentInGroupService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result), 200)]
    [ProducesResponseType(typeof(void), 404)]
    [ProducesResponseType(typeof(SystemError), 500)]
    [ProducesResponseType(typeof(Result), 400)]
    [ProducesResponseType(typeof(void), 403)]
    public async Task<ActionResult> Create(StudentInGroupCreateDto addStudentToGroupDto)
    {
        try
        {
            Guid organizationId = await _studentInGroupService.GetOrganizationIdByParentId(addStudentToGroupDto.StudentGroupId);
            await CheckOrganizationPermition(organizationId);
            addStudentToGroupDto.OrganizationId = organizationId;
            return await SendResponse(await _studentInGroupService.AddObject(addStudentToGroupDto, GetLoggedUserId(), GetClientCulture()));
        }
        catch (Exception e)
        {
            return await SendSystemError(e);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StudentInGroupListDto>), 200)]
    [ProducesResponseType(typeof(void), 404)]
    [ProducesResponseType(typeof(SystemError), 500)]
    [ProducesResponseType(typeof(Result), 400)]
    [ProducesResponseType(typeof(void), 403)]
    public async Task<ActionResult> List(
        [FromQuery] ListDeletedRequestDto requestDto,
        [FromQuery] StudentInGroupFilter filter,
        [FromQuery] SortDirection sortDirection,
        [FromQuery] StudentInGroupSort sortColum,
        [FromQuery] BasePaging paging
    )
    {
        try
        {
            await CheckOrganizationPermition(await _studentInGroupService.GetOrganizationIdByParentId(requestDto.ParentId));
            var result = await _studentInGroupService.GetList(
                    x => x.StudentGroupId == requestDto.ParentId,
                    requestDto.IsDeleted,
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

    [HttpDelete]
    [ProducesResponseType(typeof(Result), 200)]
    [ProducesResponseType(typeof(void), 404)]
    [ProducesResponseType(typeof(SystemError), 500)]
    [ProducesResponseType(typeof(Result), 400)]
    [ProducesResponseType(typeof(void), 403)]
    public async Task<ActionResult> Delete([FromQuery] DeleteDto delete)
    {
        try
        {
            await CheckOrganizationPermition(await _studentInGroupService.GetOrganizationIdByObjectId(delete.Id));
            return await SendResponse(await _studentInGroupService.DeleteObject(delete.Id, GetLoggedUserId()));
        }
        catch (Exception e)
        {
            return await SendSystemError(e);
        }
    }
}
