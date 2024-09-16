using AdminService.Route.RouteDetail.Dto;
using Core.Base.Command.Detail;
using Model.System;

namespace AdminService.Route.RouteDetail.Command
{
    public interface IRouteDetailService : IBaseDetailCommand<RouteDbo, RouteDetailDto>
    {
    }
}