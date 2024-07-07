using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Services.Permissions.Service;
using Services.Route.Service;
using Services.Setup.Dto;
using Services.Setup.Service;
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
                return SendResponse(_setupService.CreateAdministratorUser());
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
                    return SendResponse(_setupService.ImportDefaultPermitions(delete));
                }
                return BadRequest();
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
                return BadRequest();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }


    }
}
