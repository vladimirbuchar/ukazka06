using Core.Base.Service;
using EduServices.Route.Dto;
using Model.Tables.System;

namespace EduServices.Route.Service
{
    public interface IRouteService : IBaseService<RouteDbo, RouteCreateDto, RouteListDto, RouteDetailDto, RouteUpdateDto>
    {


    }
}
