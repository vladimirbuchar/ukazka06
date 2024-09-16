using AdminService.Route.RouteUpdate.Dto;
using Core.Base.Command.Update;
using Model.System;

namespace AdminService.Route.RouteUpdate.Command
{
    public interface IRouteUpdateService : IBaseUpdateCommand<RouteDbo, RouteUpdateDto>
    {
    }
}