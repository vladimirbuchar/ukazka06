using AdminService.Route.RouteList.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Model.System;

namespace AdminService.Route.RouteList.Command
{
    public interface IRouteListService : IBaseListCommand<RouteDbo, RouteListDto, RequestFilter>
    {
    }
}