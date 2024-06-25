using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Organization;
using EduServices.OrganizationRole.Service;
using EduServices.OrganizationStudyHour.Dto;
using EduServices.OrganizationStudyHour.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.OrganizationStudyHours
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationStudyHoursController : BaseClientZoneController
    {
        private readonly IOrganizationStudyHourService _organizationService;

        public OrganizationStudyHoursController(
            ILogger<OrganizationController> logger,
            IOrganizationStudyHourService organizationService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create([FromBody] StudyHourCreateDto addOrganizationDto)
        {
            try
            {
                CheckPermition(addOrganizationDto.OrganizationId);
                return SendResponse(_organizationService.AddObject(addOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<StudyHourListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(request.ParentId);
                return SendResponse(_organizationService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted));
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
        public ActionResult Update([FromBody] StudyHourUpdateDto updateStudyHoursDto)
        {
            try
            {
                CheckPermition(_organizationService.GetOrganizationIdByObjectId(updateStudyHoursDto.Id));
                return SendResponse(_organizationService.UpdateObject(updateStudyHoursDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckPermition(_organizationService.GetOrganizationIdByObjectId(delete.Id));
                return SendResponse(_organizationService.DeleteObject(delete.Id, GetLoggedUserId()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Restore([FromQuery] RestoreDto restoreDto)
        {
            try
            {
                CheckPermition(_organizationService.GetOrganizationIdByObjectId(restoreDto.Id));
                return SendResponse(_organizationService.RestoreObject(restoreDto.Id, GetLoggedUserId()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
