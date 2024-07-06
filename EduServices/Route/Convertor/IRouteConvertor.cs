using Core.Base.Convertor;
using EduServices.Route.Dto;
using Model.System;

namespace EduServices.Route.Convertor
{
    public interface IRouteConvertor : IBaseConvertor<RouteDbo, RouteCreateDto, RouteListDto, RouteDetailDto, RouteUpdateDto> { }
}
