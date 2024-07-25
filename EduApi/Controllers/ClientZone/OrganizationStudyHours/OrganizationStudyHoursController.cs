using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.OrganizationStudyHour.Dto;
using Services.OrganizationStudyHour.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Create([FromBody] StudyHourCreateDto addOrganizationDto)
        {
            try
            {
                await CheckOrganizationPermition(addOrganizationDto.OrganizationId);
                return await SendResponse(await _organizationService.AddObject(addOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<StudyHourListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _organizationService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture(), null, "position", System.Web.Helpers.SortDirection.Ascending);
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
        public async Task<ActionResult> Update([FromBody] StudyHourUpdateDto updateStudyHoursDto)
        {
            try
            {
                await CheckOrganizationPermition(await _organizationService.GetOrganizationIdByObjectId(updateStudyHoursDto.Id));
                return await SendResponse(await _organizationService.UpdateObject(updateStudyHoursDto, GetLoggedUserId(), GetClientCulture()));
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
                await CheckOrganizationPermition(await _organizationService.GetOrganizationIdByObjectId(delete.Id));
                return await SendResponse(await _organizationService.DeleteObject(delete.Id, GetLoggedUserId()));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Restore([FromQuery] RestoreDto restoreDto)
        {
            try
            {
                await CheckOrganizationPermition(await _organizationService.GetOrganizationIdByObjectId(restoreDto.Id));
                return await SendResponse(await _organizationService.RestoreObject(restoreDto.Id, GetLoggedUserId()));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
