using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Services.Route.Service;
using Services.Setup.Dto;
using Services.Setup.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.Web.UserLogin
{
    [ApiExplorerSettings(GroupName = "Setup")]
    public class SetupController : BaseWebController
    {
        private readonly ISetupService _setupService;

        public SetupController(
            ISetupService userService,
            ILogger<SetupController> logger,
            IRouteService routeService,
            IEnumerable<EndpointDataSource> endpointSources
        )
            : base(logger)
        {
            _setupService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAdministratorUser()
        {
            try
            {
                return await SendResponse(await _setupService.CreateAdministratorUser());
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> ImportDefaultPermissions([FromQuery] SetupLoginDto setupLogin, [FromQuery] bool delete = false)
        {
            try
            {
                if (await _setupService.CheckUser(setupLogin))
                {
                    return await SendResponse(await _setupService.ImportDefaultPermitions(delete));
                }

                return await SendResponse(null);

            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> RegisterAllEndPoints([FromQuery] SetupLoginDto setupLogin)
        {
            try
            {
                if (await _setupService.CheckUser(setupLogin))
                {
                    await _setupService.RegisterAllEndpoints();
                }
                return await SendResponse(true);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
