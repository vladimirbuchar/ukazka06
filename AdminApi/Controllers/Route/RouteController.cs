using AdminService.Route.RouteCreate.Command;
using AdminService.Route.RouteCreate.Dto;
using AdminService.Route.RouteDelete.Command;
using AdminService.Route.RouteDetail.Command;
using AdminService.Route.RouteDetail.Dto;
using AdminService.Route.RouteList.Command;
using AdminService.Route.RouteList.Dto;
using AdminService.Route.RouteRestore.Command;
using AdminService.Route.RouteUpdate.Command;
using AdminService.Route.RouteUpdate.Dto;
using Core.Base.Controller;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers.Route
{
    public class RouteController : BaseAdminController
    {

        private readonly IRouteCreateService _routeCreateService;
        private readonly IRouteListService _routeListService;
        private readonly IRouteDetailService _routeDetailService;
        private readonly IRouteUpdateService _routeUpdateService;
        private readonly IRouteDeleteService _routeDeleteService;
        private readonly IRouteRestoreService _routeRestoreService;



        public RouteController(

            ILogger<RouteController> logger,
            IRouteCreateService routeCreateService,
            IRouteListService routeListService,
            IRouteDetailService routeDetailService,
            IRouteUpdateService routeUpdateService,
            IRouteDeleteService routeDeleteService,
            IRouteRestoreService routeRestoreService

        )
            : base(logger)
        {
            _routeCreateService = routeCreateService;
            _routeListService = routeListService;
            _routeDetailService = routeDetailService;
            _routeUpdateService = routeUpdateService;
            _routeDeleteService = routeDeleteService;
            _routeRestoreService = routeRestoreService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(RouteCreateDto request)
        {
            try
            {
                ResultInsert result = await _routeCreateService.Execute(request, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RouteListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestWithoutParentDto request)
        {
            try
            {
                ResultTable<RouteListDto> result = await _routeListService.Execute(request.IsDeleted, [GetClientCulture()]);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(RouteDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                RouteDetailDto result = await _routeDetailService.Execute(request.Id, [GetClientCulture()]);
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
        public async Task<ActionResult> Update(RouteUpdateDto request)
        {
            try
            {
                Result rewsult = await _routeUpdateService.Execute(request, GetLoggedUserId(), GetClientCulture(), null);
                return await SendResponse(rewsult);
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
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                Result result = await _routeDeleteService.Execute(request.Id, GetLoggedUserId());
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
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                Result result = await _routeRestoreService.Execute(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
