using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.StudentInGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Service;
using System;
using System.Collections.Generic;

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
        public ActionResult Create(StudentGroupCreateDto addStudentGroupDto)
        {
            try
            {
                CheckOrganizationPermition(addStudentGroupDto.OrganizationId);
                return SendResponse(_studentGroupService.AddObject(addStudentGroupDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentGroupInOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto reuest)
        {
            try
            {
                CheckOrganizationPermition(reuest.ParentId);
                return SendResponse(_studentGroupService.GetList(x => x.OrganizationId == reuest.ParentId, reuest.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(StudentGroupDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_studentGroupService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(StudentGroupUpdateDto updateStudentGroupDto)
        {
            try
            {
                CheckOrganizationPermition(_studentGroupService.GetOrganizationIdByObjectId(updateStudentGroupDto.Id));
                return SendResponse(_studentGroupService.UpdateObject(updateStudentGroupDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_studentGroupService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_studentGroupService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_studentGroupService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
