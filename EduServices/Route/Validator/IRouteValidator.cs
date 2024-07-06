using Core.Base.Validator;
using EduRepository.RouteRepository;
using EduServices.Route.Dto;
using Model.System;

namespace EduServices.Route.Validator
{
    public interface IRouteValidator : IBaseValidator<RouteDbo, IRouteRepository, RouteCreateDto, RouteDetailDto, RouteUpdateDto> { }
}
