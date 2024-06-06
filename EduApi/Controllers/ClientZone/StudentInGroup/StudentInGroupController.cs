using Core.Base.Dto;
using Core.DataTypes;
using EduServices.OrganizationRole.Service;
using EduServices.StudentInGroup.Dto;
using EduServices.StudentInGroup.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
            CheckPermition(GetOrganizationByStudentGroupId(addStudentToGroupDto.StudentGroupId));
            addStudentToGroupDto.OrganizationId = GetOrganizationByStudentGroupId(addStudentToGroupDto.StudentGroupId);
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
    public ActionResult List([FromQuery] ListDeletedRequestDto requestDto)
    {
        try
        {
            CheckPermition(GetOrganizationByStudentGroupId(requestDto.ParentId));
            return SendResponse(_studentInGroupService.GetList(x => x.StudentGroupId == requestDto.ParentId, requestDto.IsDeleted));
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
    public ActionResult Delete(DeleteDto delete)
    {
        try
        {
            CheckPermition(GetOrganizationByStudentGroupId(delete.Id));
            _studentInGroupService.DeleteObject(delete.Id, GetLoggedUserId());
            return SendResponse();
        }
        catch (Exception e)
        {
            return SendSystemError(e);
        }
    }
}
