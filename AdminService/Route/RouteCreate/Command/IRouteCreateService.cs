using AdminService.Route.RouteCreate.Dto;
using Core.Base.Command.Create;
using Model.System;

namespace AdminService.Route.RouteCreate.Command
{
    public interface IRouteCreateService : IBaseCreateCommand<RouteDbo, RouteCreateDto> { }
}
