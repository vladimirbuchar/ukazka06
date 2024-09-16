using AdminService.Route.RouteUpdate.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Route.RouteUpdate.Convertor
{
    public interface IRouteUpdateConvertor : IBaseUpdateConvertor<RouteDbo, RouteUpdateDto>
    {
    }
}