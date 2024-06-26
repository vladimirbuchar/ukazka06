﻿using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Organization;
using EduServices.OrganizationRole.Service;
using EduServices.OrganizationSetting.Dto;
using EduServices.OrganizationSetting.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
        public ActionResult Update(OrganizationSettingUpdateDto saveOrganizationSettingDto)
        {
            try
            {
                CheckPermition(saveOrganizationSettingDto.OrganizationId);
                return SendResponse(_organizationSettingService.SaveOrganizationSetting(saveOrganizationSettingDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationSettingDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(request.Id);
                return SendResponse(_organizationSettingService.GetOrganizationSetting(request.Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
