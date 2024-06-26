﻿using Core.DataTypes;
using EduServices.Permissions.Service;
using EduServices.Route.Service;
using EduServices.Setup.Dto;
using EduServices.Setup.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace EduApi.Controllers.Web.UserLogin
{
    [ApiExplorerSettings(GroupName = "Setup")]
    public class SetupController : BaseWebController
    {
        private readonly ISetupService _setupService;

        public SetupController(ISetupService userService, ILogger<SetupController> logger, IPermissionsService permissionsService,
            IRouteService routeService,
            IEnumerable<EndpointDataSource> endpointSources)
            : base(logger)
        {
            _setupService = userService;

        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [AllowAnonymous]
        public ActionResult CreateAdministratorUser()
        {
            try
            {
                _setupService.CreateAdministratorUser();
                return SendResponse();
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ImportDefaultPermissions([FromQuery] SetupLoginDto setupLogin, [FromQuery] bool delete = false)
        {
            try
            {
                if (_setupService.CheckUser(setupLogin))
                {
                    _setupService.ImportDefaultPermitions(delete);
                }
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult RegisterAllEndPoints([FromQuery] SetupLoginDto setupLogin)
        {
            try
            {
                if (_setupService.CheckUser(setupLogin))
                {
                    _setupService.RegisterAllEndpoints();
                }
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }


    }
}
