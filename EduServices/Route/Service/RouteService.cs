using Core.Base.Service;
using EduRepository.RouteRepository;
using EduServices.Route.Convertor;
using EduServices.Route.Dto;
using EduServices.Route.Validator;
using Model.System;

namespace EduServices.Route.Service
{
    public class RouteService(
        IRouteRepository routeRepository,
        IRouteConvertor routeConvertor,
        IRouteValidator routeValidator
    )
        : BaseService<IRouteRepository, RouteDbo, IRouteConvertor, IRouteValidator, RouteCreateDto, RouteListDto, RouteDetailDto, RouteUpdateDto>(
            routeRepository,
            routeConvertor,
            routeValidator
        ),
            IRouteService
    {

    }
}
