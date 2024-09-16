using AdminService.Route.RouteList.Dto;
using Core.Base.Convertor;
using Model.System;

namespace AdminService.Route.RouteList.Convertor
{
    public interface IRouteListConvertor : IBaseListConvertor<RouteDbo, RouteListDto>
    {
    }
}