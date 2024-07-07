using Core.Base.Convertor;
using Model.System;
using Services.Route.Dto;

namespace Services.Route.Convertor
{
    public interface IRouteConvertor : IBaseConvertor<RouteDbo, RouteCreateDto, RouteListDto, RouteDetailDto, RouteUpdateDto> { }
}
