using System;
using System.Collections.Generic;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentInGroup.Dto;
using Services.StudentInGroup.Filter;
using Services.StudentInGroup.Service;

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
    public ActionResult Create(StudentInGroupCreateDto addStudentToGroupDto)
    {
        try
        {
            CheckOrganizationPermition(_studentInGroupService.GetOrganizationIdByParentId(addStudentToGroupDto.StudentGroupId));
            addStudentToGroupDto.OrganizationId = _studentInGroupService.GetOrganizationIdByParentId(addStudentToGroupDto.StudentGroupId);
            return SendResponse(_studentInGroupService.AddObject(addStudentToGroupDto, GetLoggedUserId(), GetClientCulture()));
        }
        catch (Exception e)
        {
            return SendSystemError(e);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StudentInGroupListDto>), 200)]
    [ProducesResponseType(typeof(void), 404)]
    [ProducesResponseType(typeof(SystemError), 500)]
    [ProducesResponseType(typeof(Result), 400)]
    [ProducesResponseType(typeof(void), 403)]
    public ActionResult List([FromQuery] ListDeletedRequestDto requestDto, [FromQuery] StudentInGroupFilter filter)
    {
        try
        {
            CheckOrganizationPermition(_studentInGroupService.GetOrganizationIdByParentId(requestDto.ParentId));
            return SendResponse(
                _studentInGroupService.GetList(x => x.StudentGroupId == requestDto.ParentId, requestDto.IsDeleted, GetClientCulture(), filter)
            );
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
    public ActionResult Delete([FromQuery] DeleteDto delete)
    {
        try
        {
            CheckOrganizationPermition(_studentInGroupService.GetOrganizationIdByObjectId(delete.Id));
            return SendResponse(_studentInGroupService.DeleteObject(delete.Id, GetLoggedUserId()));
        }
        catch (Exception e)
        {
            return SendSystemError(e);
        }
    }
}
