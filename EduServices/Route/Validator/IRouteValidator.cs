using Core.Base.Validator;
using Model.System;
using Repository.RouteRepository;
using Services.Route.Dto;

namespace Services.Route.Validator
{
    public interface IRouteValidator : IBaseValidator<RouteDbo, IRouteRepository, RouteCreateDto, RouteDetailDto, RouteUpdateDto> { }
}
