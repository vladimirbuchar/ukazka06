﻿using Core.Constants;
using Core.Exceptions;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace EduApi.Controllers.ClientZone
{
    [Route("api/clientzone/[controller]/[action]")]
    [Authorize(Policy = "ClientPolicy")]
    [ApiExplorerSettings(GroupName = "ClientZone")]
    public class BaseClientZoneController : BaseController
    {
        private readonly IOrganizationRoleService _organizationRoleService;
        public BaseClientZoneController(ILogger<BaseClientZoneController> logger, IOrganizationRoleService organizationRoleService)
            : base(logger)
        {
            _organizationRoleService = organizationRoleService;
        }

        private Dictionary<Guid, List<string>> GetUserRoleInOrganization()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (authHeader == null)
            {
                return new Dictionary<Guid, List<string>>();
            }
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            return JsonConvert.DeserializeObject<Dictionary<Guid, List<string>>>(tokenS.Claims.FirstOrDefault(x => x.Type == Constants.UserOrganizationRole).Value);
        }

        /// <summary>
        /// check user permition in organization
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        protected void CheckPermition(Guid organizationId)
        {
            if (_organizationRoleService != null && !_organizationRoleService.CheckPermition(GetLoggedUserId(), organizationId, Request.Path, GetUserRoleInOrganization().GetValueOrDefault(organizationId)))
            {
                throw new PermitionDeniedException();
            }
        }
    }
}
