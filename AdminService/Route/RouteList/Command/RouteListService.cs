using AdminService.Route.RouteList.Convertor;
using AdminService.Route.RouteList.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteList.Command
{
    public class RouteListService : BaseListCommand<RouteDbo, IRouteRepository, RouteListDto, IRouteListConvertor, RequestFilter>, IRouteListService
    {
        public RouteListService(IRouteRepository repository, IRouteListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
