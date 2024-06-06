using Core.Base.Validator;
using EduRepository.RouteRepository;
using EduServices.Route.Dto;
using Model.Tables.System;

namespace EduServices.Route.Validator
{
    public class RouteValidator(IRouteRepository repository)
        : BaseValidator<RouteDbo, IRouteRepository, RouteCreateDto, RouteDetailDto, RouteUpdateDto>(repository),
            IRouteValidator
    {
    }
}
