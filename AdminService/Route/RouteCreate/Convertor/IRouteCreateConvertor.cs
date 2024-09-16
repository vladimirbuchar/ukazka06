using AdminService.Route.RouteCreate.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Route.RouteCreate.Convertor
{
    public interface IRouteCreateConvertor : IBaseCreateConvertor<RouteDbo, RouteCreateDto> { }
}
