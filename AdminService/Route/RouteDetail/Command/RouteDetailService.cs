using AdminService.Route.RouteDetail.Convertor;
using AdminService.Route.RouteDetail.Dto;
using Core.Base.Command.Detail;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteDetail.Command
{
    public class RouteDetailService : BaseDetailCommand<RouteDbo, IRouteRepository, RouteDetailDto, IRouteDetailConvertor>, IRouteDetailService
    {
        public RouteDetailService(IRouteRepository repository, IRouteDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
