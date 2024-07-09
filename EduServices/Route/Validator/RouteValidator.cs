using Core.Base.Validator;
using Model.System;
using Repository.RouteRepository;
using Services.Route.Dto;

namespace Services.Route.Validator
{
    public class RouteValidator(IRouteRepository repository)
        : BaseValidator<RouteDbo, IRouteRepository, RouteCreateDto, RouteDetailDto, RouteUpdateDto>(repository),
            IRouteValidator { }
}
