using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.OrganizationSetting.Dto;
using Services.OrganizationSetting.Service;
using System;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.OrganizationSetting
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationSettingController : BaseClientZoneController
    {
        private readonly IOrganizationSettingService _organizationSettingService;

        public OrganizationSettingController(
            ILogger<OrganizationController> logger,
            IOrganizationSettingService organizationSettingService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _organizationSettingService = organizationSettingService;
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(OrganizationSettingUpdateDto saveOrganizationSettingDto)
        {
            try
            {
                await CheckOrganizationPermition(saveOrganizationSettingDto.OrganizationId);
                return await SendResponse(await _organizationSettingService.SaveOrganizationSetting(saveOrganizationSettingDto));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationSettingDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(request.Id);
                return await SendResponse(await _organizationSettingService.GetOrganizationSetting(request.Id));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
