using Core.Base.Service;
using Model.System;
using Services.Route.Dto;

namespace Services.Route.Service
{
    public interface IRouteService : IBaseService<RouteDbo, RouteCreateDto, RouteListDto, RouteDetailDto, RouteUpdateDto>
    {

    }
}
