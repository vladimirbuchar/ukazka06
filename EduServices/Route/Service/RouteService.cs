using Core.Base.Request;
using Core.Base.Service;
using Model.System;
using Repository.RouteRepository;
using Services.Route.Convertor;
using Services.Route.Dto;
using Services.Route.Validator;

namespace Services.Route.Service
{
    public class RouteService(IRouteRepository routeRepository, IRouteConvertor routeConvertor, IRouteValidator routeValidator)
        : BaseService<
            IRouteRepository,
            RouteDbo,
            IRouteConvertor,
            IRouteValidator,
            RouteCreateDto,
            RouteListDto,
            RouteDetailDto,
            RouteUpdateDto,
            FilterRequest
        >(routeRepository, routeConvertor, routeValidator),
            IRouteService { }
}
